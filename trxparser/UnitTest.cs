using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
  [Serializable]
    public class UnitTest
    {
      [XmlAttribute("id")]
        public string Id { get; set; }
      [XmlAttribute("name")]
        public string Name { get; set; }
      [XmlAttribute("storage")]
        public string Storage { get; set; }
      [XmlElement("Execution")]
        public Execution Execution { get; set; }
      [XmlElement("TestMethod")]
        public TestMethod TestMethod { get; set; }
    }

}
