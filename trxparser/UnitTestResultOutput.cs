using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
    [Serializable]
    public class UnitTestResultOutput
    {
        [XmlElement]
        public string StdOut { get; set; }
        [XmlElement]
        public string StdErr { get; set; }
        [XmlElement]
        public ErrorInfo ErrorInfo { get; set; }
    }
}
