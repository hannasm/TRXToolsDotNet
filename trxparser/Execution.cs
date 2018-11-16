using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
  [Serializable]
    public class Execution
    {
      [XmlAttribute("id")]
        public string Id { get; set; }
    }
}
