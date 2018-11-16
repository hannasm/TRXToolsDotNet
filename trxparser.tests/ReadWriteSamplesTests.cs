using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrxTools.TrxParser.Tests
{
    [TestClass]
    public class ReadWriteSamplesTests
    {

        public string GetFileInParentPath(string filename, string path) {
          if (File.Exists(Path.Combine(path, filename))) {
            return Path.Combine(path, filename);
          }

          path = Path.Combine(path, "..");
          if (!Directory.Exists(path)) {
            throw new FileNotFoundException("Unable to locate file, stopping at path " + path);
          }

          return GetFileInParentPath(filename, path);
        }

        [TestMethod]
        public void TestMethod1()
        {
          var filename = GetFileInParentPath("trxSample001.trx", Environment.CurrentDirectory);
          using (var inStream = File.OpenRead(filename))
          using (var outStream = File.OpenWrite(filename + ".out"))
          {
            var result = TrxControl.ReadTrx(inStream);
            TrxControl.WriteTrx(result, outStream);
          }
        }
        [TestMethod]
        public void TestMethod2()
        {
          var filename = GetFileInParentPath("trxSample002.trx", Environment.CurrentDirectory);
          using (var inStream = File.OpenRead(filename))
          using (var outStream = File.OpenWrite(filename + ".out"))
          {
            var result = TrxControl.ReadTrx(inStream);
            TrxControl.WriteTrx(result, outStream);
          }
        }
    }
}
