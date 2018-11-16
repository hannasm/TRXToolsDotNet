using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
    public class TestList
    {
      [XmlAttribute("name")]
        public string Name { get; set; }
      [XmlAttribute("id")]
        public string Id { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is TestList))
                return false;
            return (obj as TestList).Id == Id;
        }

        public override int GetHashCode()
        {
            return Guid.Parse(Id).GetHashCode();
        }
    }
}
