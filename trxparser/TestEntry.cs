using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
  [Serializable]
    public class TestEntry
    {
      [XmlAttribute("testId")]
        public string TestId { get; set; }
      [XmlAttribute("executionId")]
        public string ExecutionId { get; set; }
      [XmlAttribute("testListId")]
        public string TestListId { get; set; }
    }
}
