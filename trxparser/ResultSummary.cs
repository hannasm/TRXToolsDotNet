using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
  [Serializable]
    public class ResultSummary
    {
      [XmlAttribute("outcome")]
        public string Outcome { get; set; }
      [XmlElement]
        public Counters Counters { get; set; }
      [XmlElement]
        public List<RunInfo> RunInfos { get; set; }
    }
}
