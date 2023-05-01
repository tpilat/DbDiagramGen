using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VisualXmlDiff
{
    class XmlTools
    {
        public static void orderXmlFilesAlphabetically(string directoryPath)
        {
            //loop files in directory2 to figure out if they exist in directory1
            foreach (var file in new DirectoryInfo(directoryPath).GetFiles("*.xsd"))
            {
                //find corresponding file in first directory and report error if not found
                orderXmlFileAlphabetically(file.FullName);
            }
            //loop subdirectories
            foreach (var directory in new DirectoryInfo(directoryPath).GetDirectories())
            {
                orderXmlFilesAlphabetically(directory.FullName);
            }

        }
        public static void orderXmlFileAlphabetically(string filePath)
        {
            var xdoc = XDocument.Load(filePath);
            //sort the elements
            SortElementsInPlace(xdoc.Root);
            xdoc.Save(filePath);
        }
        public static void SortElementsInPlace(XContainer xContainer)
        {
            var orderedElements = (from child in xContainer.Elements()
                                   orderby child.Attribute("name")?.Value, child.Name.LocalName
                                   select child).ToList();  // ToList matters, since we remove all of the child elements next

            xContainer.Elements().Remove();
            xContainer.Add(orderedElements);
        }
    }
}
