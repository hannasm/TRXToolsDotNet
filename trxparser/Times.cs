using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TrxTools.TrxParser
{
    [Serializable] 
    public class Times
    {
        [XmlAttribute("creation")]
        public string Creation { get; set; }
        [XmlAttribute("queuing")]
        public string Queuing { get; set; }
        [XmlAttribute("start")]
        public string Start { get; set; }
        [XmlAttribute("finish")]
        public string Finish { get; set; }
    }
}
