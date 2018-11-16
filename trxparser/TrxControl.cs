using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TrxTools.TrxParser;

namespace TrxTools.TrxParser
{
  public static class TrxControl {

    public static XmlSerializer GetSerializer() {
      return new XmlSerializer(typeof(TestRun), new XmlRootAttribute("TestRun") { Namespace="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"});
    }

    public static XmlWriterSettings GetSettings_NoFormatting() {
      return new XmlWriterSettings() {
        Encoding = Encoding.UTF8,
        NewLineHandling = NewLineHandling.None,
        Indent = false,
      };
    }

    public static XmlSerializerNamespaces GetNamespaces() {
      XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
      ns.Add("","http://microsoft.com/schemas/VisualStudio/TeamTest/2010");
      return ns;
    }

    public static TestRun ReadTrx(Stream stream) {
      return (TestRun)GetSerializer().Deserialize(stream);
    }
    public static TestRun ReadTrx(TextReader reader) {
      return (TestRun)GetSerializer().Deserialize(reader);
    }

    public static void WriteTrx(TestRun tests, Stream stream) {
      WriteTrx(tests, stream, GetSettings_NoFormatting());
    }
    public static void WriteTrx(TestRun tests, TextWriter stream) {
      WriteTrx(tests, stream, GetSettings_NoFormatting());
    }
    public static void WriteTrx(TestRun tests, StringBuilder stream) {
      WriteTrx(tests, stream, GetSettings_NoFormatting());
    }
    public static void WriteTrx(TestRun tests, Stream stream, XmlWriterSettings settings) {
      using (var xw = XmlWriter.Create(stream, settings)) {
        var ser = GetSerializer();
        ser.Serialize(xw, tests, GetNamespaces());
      }
    }
    public static void WriteTrx(TestRun tests, TextWriter stream, XmlWriterSettings settings) {
      using (var xw = XmlWriter.Create(stream, settings)) {
        var ser = GetSerializer();
        ser.Serialize(xw, tests, GetNamespaces());
      }
    }
    public static void WriteTrx(TestRun tests, StringBuilder stream, XmlWriterSettings settings) {
      using (var xw = XmlWriter.Create(stream, settings)) {
        var ser = GetSerializer();
        ser.Serialize(xw, tests, GetNamespaces());
      }
    }
  }
}
