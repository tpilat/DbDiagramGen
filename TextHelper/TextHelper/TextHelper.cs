using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextHelper
{
    public class TextHelper
    {
        /// <summary>
        /// adds '" ' (double quote + space) at the front of the each line (except on the first line, there its only a double quote
        /// adds ' " & vbNewLine & _' to each line (with the appropriate amount of spaces, making each line the same length, except for the last line, there the ' & vbNewLine & _ is not added
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static string formatSQLtoVBS(string sqlString)
        {
            int maxLineLenght = 0;
            //get max length of the line in the string
            using (StringReader reader = new StringReader(sqlString))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var lineLenght = ExpandTabs("\" " + line).Length + 2; 
                    if (lineLenght > maxLineLenght)
                    {
                        maxLineLenght = lineLenght;
                    }
                }
            }
            string previousLine = null;
            var newString = string.Empty;
            //now loop again over the lines and add 
            using (StringReader reader = new StringReader(sqlString))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (previousLine != null)
                    {
                        newString += formatLine(previousLine, newString == string.Empty, false, maxLineLenght);
                    }
                    //set the previous line
                    previousLine = line;
                }
            }
            //do the last line
            if (previousLine != null)
            {
                newString += formatLine(previousLine, false, true, maxLineLenght);
            }
            //return
            return newString;
        }
        private static string formatLine(string line, bool firstLine, bool lastLine, int maxLineLenght)
        {
            var formattedLine = string.Empty;
            var prefix = "\"";
            if (!firstLine) prefix += " "; //don't extra space for first line
            //get number of spaces to add
            var spacedNeeded = maxLineLenght - ExpandTabs(prefix + line).Length + 1;
            //add the end of the string
            formattedLine = prefix + line + String.Empty.PadLeft(spacedNeeded, ' ') + "\"";
            if (!lastLine) formattedLine += " & vbNewLine & _" + Environment.NewLine;
            return formattedLine;
        }
        public static string formatVBStoSQL(string vbsString)
        {
            var sqlString = vbsString;
            //remove '" ' (with or without space) at the beginning of the line
            var prefixRegex = new Regex(@"^([\t]+)?""[ ]?", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            sqlString = prefixRegex.Replace(sqlString, string.Empty);
            //remove trailing '" & vbNewLine & _
            var suffixRegex = new Regex(@"(\s+)?""( & vbNewLine & _)?\r?$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            //add the newline again
            sqlString = suffixRegex.Replace(sqlString, "\r");
            //return
            return sqlString;
        }

        /// <summary>
        /// expands each tab into up to 4 spaces
        /// copied from StackOverflow: https://stackoverflow.com/questions/508033/convert-tabs-to-spaces-in-a-net-string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="tabLength"></param>
        /// <returns>the updated string with spaces instead of tabs</returns>
        public static string ExpandTabs(string input, int tabLength = 4)
        {
            string[] parts = input.Split('\t');
            int count = 0;
            int maxpart = parts.Count() - 1;
            foreach (string part in parts)
            {
                if (count < maxpart)
                    parts[count] = part + new string(' ', tabLength - (part.Length % tabLength));
                count++;
            }
            return (string.Join("", parts));
        }
    }
}
