using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
  [Serializable]
    public class RunInfo
    {
      [XmlAttribute("computerName")]
        public string ComputerName { get; set; }
      [XmlAttribute("outcome")]
        public string Outcome { get; set; }
      [XmlAttribute("timestamp")]
        public string Timestamp { get; set; }
      [XmlElement]
        public string Text { get; set; }
    } 
}
