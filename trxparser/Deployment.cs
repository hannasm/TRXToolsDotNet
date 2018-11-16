using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrxTools.TrxParser
{
    [Serializable]
    public class Deployment
    {
      [XmlAttribute("runDeploymentRoot")]
      public string RunDeploymentRoot;
    }
}
