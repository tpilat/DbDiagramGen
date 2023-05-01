using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using Microsoft.XmlDiffPatch;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Text.RegularExpressions;

namespace VisualXmlDiff
{
    class XmlComparer
    {

        private string currentLog;
        public string doCompare(string path1, string path2, string resultPath, XmlDiffOptions diffOptions, bool compareFragments, bool ignoreRefTypeDifferences, XmlDiffAlgorithm algorithm)
        {
            //compare
            var results = compareDirectories( path1,  path2,  resultPath,  diffOptions,  compareFragments,ignoreRefTypeDifferences, algorithm);
            //create the results overview
            return createResultsOverview(resultPath, results);
        }
        private List<CompareResult> compareDirectories(string path1, string path2, string resultPath, XmlDiffOptions diffOptions, bool compareFragments, bool ignoreRefTypeDifferences, XmlDiffAlgorithm algorithm)
        {
            string currentLog = string.Empty;
            var results = new List<CompareResult>();

            //loop files in the directory1
            foreach (var file in new DirectoryInfo(path1).GetFiles("*.xsd"))
            {
                
                //find corresponding file in second directory
                var file2 = Path.Combine(path2, file.Name);
                if (File.Exists(file2))
                    results.Add(compareFiles(file.FullName, file2, resultPath, diffOptions, compareFragments, ignoreRefTypeDifferences, algorithm));
                else
                {
                    log(resultPath, string.Format("Compared file missing for: '{0}'", file2), true);
                    results.Add(new CompareResult()
                    {
                        originalFile = file.FullName,
                        comparedFile = file2,
                        resultType = CompareResultType.comparedFileMissing
                    });
                }
            }
            //loop files in directory2 to figure out if they exist in directory1
            foreach (var file in new DirectoryInfo(path2).GetFiles("*.xsd"))
            {
                //find corresponding file in first directory and report error if not found
                var file2 = Path.Combine(path1, file.Name);
                if (!File.Exists(file2))
                {
                    log(resultPath, string.Format("Original file missing for: '{0}'", file2), true);
                    results.Add(new CompareResult()
                    {
                        originalFile = file2,
                        comparedFile = file.FullName,
                        resultType = CompareResultType.originalFileMissing
                    });
                }
            }
            //loop subdirectories
            foreach (var directory in new DirectoryInfo(path1).GetDirectories())
            {
                var directory2 = Path.Combine(path2, directory.Name);
                if (Directory.Exists(directory2))
                    results.AddRange(compareDirectories(directory.FullName, directory2, resultPath, diffOptions, compareFragments,ignoreRefTypeDifferences, algorithm));
            }
            return results;
        }
        private string createResultsOverview(string resultsPath, List<CompareResult> results)
        {
            //create a csv file with an overview of the results
            var file = resultsPath + @"\compareOverview.csv";
            try
            {
                using (var stream = File.CreateText(file))
                {
                    foreach (var result in results)
                    {
                        stream.WriteLine(result.toCsvRow());
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show("Error writing results file!" + Environment.NewLine + e.Message);
            }
            return file;
        }
        public event EventHandler onLogProgress;
        private void log(string logFilePath, string message, bool toFile)
        {
            var e = new EventArgs();
            var sender = message;
            onLogProgress(sender, e);

            this.currentLog += message + Environment.NewLine;
            string logFileName = logFilePath + @"\XSDCompare.log";
            try
            {
                System.IO.StreamWriter logfile = new System.IO.StreamWriter(logFileName, true);
                logfile.WriteLine(System.DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss.fff") + ": " + message);
                logfile.Close();
            }
            catch (Exception)
            {
                // do nothing. If the logging fails we don't want to log anything to avoid eternal loops
            }
        }
        public CompareResult compareFiles(string file1, string file2, string resultPath, XmlDiffOptions diffOptions, bool compareFragments, bool ignoreRefTypeDifferences, XmlDiffAlgorithm algorithm)
        {

            // canonicalize files
            file1 = canonicalize(file1);
            if (ignoreRefTypeDifferences) file1 = refToType(file1);
            file2 = canonicalize(file2);
            if (ignoreRefTypeDifferences) file2 = refToType(file2);

            //The main class which is used to compare two files.
            XmlDiff diff = new XmlDiff();
            diff.Options = diffOptions;
            diff.Algorithm = algorithm;

            //output diff file.
            string diffFile = resultPath + Path.DirectorySeparatorChar + "vxd.out";
            XmlTextWriter tw = new XmlTextWriter(new StreamWriter(diffFile));
            tw.Formatting = Formatting.Indented;

            bool isEqual = false;
            //Now compare the two files.
            try
            {
                isEqual = diff.Compare(file1, file2, compareFragments, tw);
            }
            catch (XmlException xe)
            {
                MessageBox.Show("An exception occured while comparing\n" + xe.StackTrace);
            }
            finally
            {
                tw.Close();
            }
            
            if (isEqual)
            {
                //log result
                this.log(resultPath, string.Format("Files are equal for: '{0}'", file1), false);
                //This means the files were identical for given options.
                return new CompareResult()
                {
                    originalFile = file1,
                    comparedFile = file2,
                    resultType = CompareResultType.comparedEqual
                };
            }
            else
            {
                //log result
                this.log(resultPath, string.Format("Difference found for: '{0}'", file1), false);
                var resultDetailsFile = createResultFile(file1, file2, resultPath, diffFile);
                return new CompareResult()
                {
                    originalFile = file1,
                    comparedFile = file2,
                    resultType = CompareResultType.comparedDifferent,
                    detailsFile = resultDetailsFile
                };
            }

        }

        private static string createResultFile(string file1, string file2, string resultPath, string diffFile)
        {
            //Files were not equal, so construct XmlDiffView.
            XmlDiffView dv = new XmlDiffView();

            //Load the original file again and the diff file.
            XmlTextReader orig = new XmlTextReader(file1);
            XmlTextReader diffGram = new XmlTextReader(diffFile);
            dv.Load(orig, diffGram);

            //create the HTML output
            var resultDetailFile = createHtmlResult(file1, file2, resultPath, dv);

            //cleanup
            dv = null;
            orig.Close();
            diffGram.Close();
            File.Delete(diffFile);
            return resultDetailFile;
        }

        private static string createHtmlResult(string file1, string file2, string resultPath, XmlDiffView dv)
        {
            string outputFile = resultPath + Path.DirectorySeparatorChar + new FileInfo(file1).Name + "_compare.html";
            StreamWriter sw1 = new StreamWriter(outputFile);
            //Wrap the HTML file with necessary html and 
            //body tags and prepare it before passing it to the GetHtml method.
            sw1.Write("<html><body><table width='100%'>");
            //Write Legend.
            sw1.Write(@"<tr><td colspan=""2"" align=""center""><b>Legend:</b> <font style=""background-color: yellow"" 
                 color=""black"">added</font>&nbsp;&nbsp;<font style=""background-color: red""
                 color=""black"">removed</font>&nbsp;&nbsp;<font style=""background-color: 
                lightgreen"" color=""black"">changed</font>&nbsp;&nbsp;
                <font style=""background-color: red"" color=""blue"">moved from</font>
                &nbsp;&nbsp;<font style=""background-color: yellow"" color=""blue"">moved to
                </font>&nbsp;&nbsp;<font style=""background-color: white"" color=""#AAAAAA"">
                ignored</font></td></tr>");


            sw1.Write("<tr><td><b> File Name : ");
            sw1.Write(file1);
            sw1.Write("</b></td><td><b> File Name : ");
            sw1.Write(file2);
            sw1.Write("</b></td></tr>");

            //This gets the differences but just has the 
            //rows and columns of an HTML table
            dv.GetHtml(sw1);

            //Finish wrapping up the generated HTML and complete the file.
            sw1.Write("</table></body></html>");
            //HouseKeeping...close everything we dont want to lock.
            sw1.Close();
            //read the file again and change colors
            // red + blue => plum + blue, yellow + blue => LightCyan + blue
            string text = File.ReadAllText(outputFile);
            text = text.Replace("red\" color=\"blue", "Plum\" color=\"blue");
            text = text.Replace("yellow\" color=\"blue", "LightCyan\" color=\"blue");
            File.WriteAllText(outputFile, text);
            return outputFile;
        }

        private string canonicalize(string file)
        {
            file = orderAndformat(file);
            //create c14n instance and load in xml file
            XmlDsigC14NTransform c14n = new XmlDsigC14NTransform(false);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            c14n.LoadInput(xmlDoc);

            //get canonalised stream
            Stream s1 = (Stream)c14n.GetOutput(typeof(Stream));

            //create new xmldocument and save
            String newFilename = file + ".canonical";
            XmlDocument xmldoc2 = new XmlDocument();
            xmldoc2.Load(s1);
            xmldoc2.Save(newFilename);

            return newFilename;
        }
        private string orderAndformat(string file)
        {
            var xdoc = XDocument.Load(file);
            //remove any empty nodes
            removeEmptyNodes(xdoc);
            //sort the elements
            this.SortElementsInPlace(xdoc.Root);
            string newFileName = file + ".ordered";
            xdoc.Save(newFileName);
            return newFileName;
        }
        private string refToType(string file)
        {
            var fileContents = File.ReadAllText(file);
            string newContents = fileContents;
            //get the ref instances
            var refPattern = "<xsd:element maxOccurs=\"([0-9]+|unbounded)\" minOccurs=\"([0-9]+)\" ref=\"rsm:([\\w]+)\">";
            Regex regex = new Regex(refPattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(newContents);
            bool found = false;
            while (match.Success)
            {
                string fullMatch = match.Groups[0].Value;
                string maxOccurs = match.Groups[1].Value;
                string minOccurs = match.Groups[2].Value;
                string refElementName = match.Groups[3].Value;
                //find the ref element type
                var refElemenType = getRefElementType(refElementName, fileContents);
                //replace the reference with a type 
                newContents = newContents.Replace(fullMatch, $"<xsd:element maxOccurs=\"{maxOccurs}\" minOccurs=\"{minOccurs}\" name=\"{refElementName}\" type=\"rsm:{refElemenType}\">");
                match = match.NextMatch();
            }
            var newFileName = file + ".typ";
            File.WriteAllText(newFileName, newContents);
            return newFileName;
        }
        private string getRefElementType(string refElementName, string fileContents)
        {
            var refPattern = $"<xsd:element name=\"{refElementName}\" type=\"rsm:([\\w]+)\">";
            Regex regex = new Regex(refPattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(fileContents);
            if (match.Success) return match.Groups[1].Value;
            throw new Exception($"Coud not match {refElementName} to an existing element");
        }
        private void removeEmptyNodes(XDocument xdoc)
        {
            xdoc.Descendants()
                    .Where(x => (x.IsEmpty || String.IsNullOrWhiteSpace(x.Value))
                                && !x.HasAttributes && !x.HasElements)
                    .Remove();
        }
        public void SortElementsInPlace(XContainer xContainer)
        {
            var orderedElements = (from child in xContainer.Elements()
                                   orderby child.Name.LocalName, child.Attribute("name")?.Value
                                   select child).ToList();  // ToList matters, since we remove all of the child elements next

            xContainer.Elements().Remove();
            xContainer.Add(orderedElements);
        }
    }
}
