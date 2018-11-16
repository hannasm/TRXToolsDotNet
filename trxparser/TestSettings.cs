using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
    [Serializable]
    public class TestSettings
    {
      [XmlAttribute("name")]
      public string Name;
      [XmlAttribute("id")]
      public Guid id;
      [XmlElement]
      public Deployment Deployment;
    }
}
