using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TrxTools.TrxParser
{
    [Serializable]
    public class ErrorInfo
    {
        [XmlElement]
        public string Message;
        [XmlElement]
        public string StackTrace;
    } 
}
