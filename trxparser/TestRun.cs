using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
  [Serializable]
  [XmlRoot("TestRun", Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
    public class TestRun
    {
      [XmlAttribute("id")]
        public string Id { get; set; }
      [XmlAttribute("name")]
        public string Name { get; set; }
      [XmlAttribute("runUser")]
        public string RunUser { get; set; } 
      [XmlElement]
        public Times Times { get; set; }
      [XmlElement]
      public TestSettings TestSettings { get; set; }

        public string Duration
        {
            get
            {
                return (DateTime.Parse(Times.Finish) - DateTime.Parse(Times.Start)).ToString("hh\\:mm\\:ss");
            }
        }
        
        [XmlArray("Results")]
        [XmlArrayItem("UnitTestResult")]
        public UnitTestResult[] Results { get; set; }

        [XmlArray("TestDefinitions")]
        [XmlArrayItem("UnitTest")]
        public List<UnitTest> TestDefinitions { get; set; }
        [XmlArray("TestEntries")]
        [XmlArrayItem("TestEntry")]
        public List<TestEntry> TestEntries { get; set; }
        [XmlArray("TestLists")]
        [XmlArrayItem("TestList")]
        public List<TestList> TestLists { get; set; }
        [XmlElement]
        public ResultSummary ResultSummary { get; set; }

        private XmlSerializerNamespaces _namespaces;
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces Namespaces {
          get {
            if (_namespaces == null) {
              _namespaces = new XmlSerializerNamespaces(
                  new XmlQualifiedName[] {
                    new XmlQualifiedName(string.Empty, "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")
                  }
              );
            }
            return _namespaces;
          }
        }
    }
}
