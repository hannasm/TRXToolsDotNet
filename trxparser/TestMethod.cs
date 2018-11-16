using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
    [Serializable]
    public class TestMethod
    {
        [XmlAttribute("codeBase")]
        public string CodeBase { get; set; }
        [XmlAttribute("adapterTypeName")]
        public string AdapterTypeName { get; set; }
        [XmlAttribute("className")]
        public string ClassName { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
