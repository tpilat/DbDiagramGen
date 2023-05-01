using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualXmlDiff
{
    public class CompareResult
    {
        public string originalFile { get; set; }
        public string comparedFile { get; set; }
        public CompareResultType resultType { get; set; }
        public string detailsFile { get; set; }

        internal string toCsvRow()
        {
            return string.Format("{0};{1};{2};{3}"
                , originalFile
                , comparedFile
                , Enum.GetName(resultType.GetType(), resultType)
                , detailsFile);
        }
    }
    public enum CompareResultType
    {
        comparedEqual,
        comparedDifferent,
        originalFileMissing,
        comparedFileMissing
    }
}
