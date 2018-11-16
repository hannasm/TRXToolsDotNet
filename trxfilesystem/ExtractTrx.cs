using System.IO;
using System.Collections.Generic;
using System;
using System.Text;
using TrxTools.TrxParser;
using Mono.Options;

namespace TrxTools.TrxFilesystem
{
  public class ExtractTrx {

    static int Main(string[] args)
    {
      bool help = false;
      List<string> InFiles = new List<string>();
      string DestinationFolder = null;

      var options = new OptionSet() {
        "",
        "Usage: trxfilesystem [-f <filename>]+ -d <destination>",
        "Extract trx file into constituent pieces inside filesystem",
        "",
        {"h|help", "show help message", v=>help=v!=null},
        {"f|file=", "The file to extract", option=> InFiles.Add(option)},
        {"d|destination=", "The directory to extract into", option=> DestinationFolder = option},
        ""
      };

      try {
        options.Parse(args);
      } catch (OptionException eError) {
        Console.WriteLine(eError.ToString());
        Console.WriteLine();
        Console.WriteLine("Use --help for usage");
        return 1;
      }

      if (help) {
        options.WriteOptionDescriptions(Console.Out);
        return 0;
      }

      if (DestinationFolder == null || InFiles.Count == 0) {
        Console.WriteLine("Directory and File required");
        options.WriteOptionDescriptions(Console.Out);
        return 2;
      }

      var dir = Directory.GetCurrentDirectory();
      try {
        foreach (var InFile in InFiles) {
          var extract = new ExtractTrx(InFile, DestinationFolder);
          Directory.SetCurrentDirectory(dir);
        }
      } finally {
        Directory.SetCurrentDirectory(dir);
      }

      return 0;
    }

    public ExtractTrx(string InFile, string DestinationFolder) {
        if (!File.Exists(InFile)) {
          throw new FileNotFoundException(InFile);
        }

        if (File.Exists(DestinationFolder)) {
          throw new DirectoryNotFoundException(DestinationFolder);
        }

        pushd(Directory.GetCurrentDirectory());

        if (!Directory.Exists(DestinationFolder)) {
          Directory.CreateDirectory(DestinationFolder);
        }
        
        using (var inStream = File.OpenRead(InFile)) {
          var trxData = TrxControl.ReadTrx(inStream);

          try {
            pushd(DestinationFolder);
            extract(trxData);
          } finally {
            popc();
          }
        }
    }

    Dictionary<string, string> _testIdToPath = new Dictionary<string, string>();
    void pushd(UnitTest ut) {
      var path = _testIdToPath[ut.Id];
      pushd(path);
    }
    void pushd(UnitTestResult utr) {
      var path = utr.Outcome + "_tests";
      ensureDirectory(path);

      path = Path.Combine(path, safeName(utr.TestId + "_" + utr.TestName));
      ensureDirectory(path);
      pushd(path);

      _testIdToPath.Add(utr.TestId, path);
    }

    Stack<string> cwd = new Stack<string>();
    void pushd(string path) {
      path = Path.GetFullPath(path);
      cwd.Push(path);
      Directory.SetCurrentDirectory(path);
    }
    void popd() {
      cwd.Pop();
      Directory.SetCurrentDirectory(cwd.Peek());
    }
    void popc() {
      string path = null;
      while (cwd.Count > 0) {
        path = cwd.Pop();
      }
      pushd(path);
    }

    string fullpath(string path) {
      return Path.Combine(Directory.GetCurrentDirectory(), path );
    }

    void wfnz(string name, long value) {
      if (value == 0) { return; }
      wf(name, value);
    }
    void wfnn(string name, string value) {
      if (value == null) {  return; }
      wf(name, value);
    }
    void wf(string name, long value) {
      wf(name, value.ToString());
    }
    void wf(string name, string value) {
      if (value == null) { value = string.Empty; }

      File.WriteAllText(name, value);
    }

    void ensureDirectory(string path) {
      if (File.Exists(path)) {
        throw new InvalidOperationException("Unable to create directory at " + fullpath(path));
      }
      if (!Directory.Exists(path)) {
        Directory.CreateDirectory(path);
      }
    }
    string safeName(string name) {
      var result = new StringBuilder();
      var illegalChars = new  HashSet<char>() {
        '@', ' ', ':', '-'
      };
      foreach (var c in Path.GetInvalidFileNameChars()) {
        illegalChars.Add(c);
      }
  
      bool first = true;
      int illegals = 0;
      foreach (var c in name) {
        if (illegalChars.Contains(c)) {
          illegals++;
          continue;
        }
        if (illegals > 0 && !first) {
          result.Append("_");
          illegals = 0;
        }
        first = false;

        result.Append(c);
      }

      return result.ToString();
    }



    void extract(TestRun trxData) {
      var sn = safeName(trxData.Name);
        if (File.Exists(sn)) {
          throw new InvalidOperationException("Test run " + sn + " already exists in directory " + fullpath(sn));
        }

        Directory.CreateDirectory(sn);
        pushd(sn);

        wf("runUser", trxData.RunUser);
        wf("id", trxData.Id);
        wf("name", trxData.Name);

        extract(trxData.ResultSummary);
        extract(trxData.Times);

        foreach (var result in trxData.Results) {
          extract(result);
        }
        foreach (var definition in trxData.TestDefinitions) {
          extract(definition);
        }
    }

    void extract(UnitTest ut) {
      if (ut == null) { return; } 

      pushd(ut);

      wfnn("storage", ut.Storage);
      wfnn("codebase", ut.TestMethod.CodeBase);
      wfnn("adapterTypeName", ut.TestMethod.AdapterTypeName);
      wfnn("className", ut.TestMethod.ClassName);
      wfnn("methodName", ut.TestMethod.Name);
      wfnn("fullName", ut.TestMethod.ClassName + "." + ut.TestMethod.Name);

      popd();
    }
    
    void extract(UnitTestResult utr) {
      if (utr == null) { return; }

      pushd(utr);

      try {
        wfnn("testId", utr.TestId);
        wfnn("testName", utr.TestName);
        wfnn("computerName", utr.ComputerName);
        wfnn("duration", utr.Duration);
        wfnn("startTime", utr.StartTime);
        wfnn("endTime", utr.EndTime);
        wfnn("testType", utr.TestType);
        wfnn("outcome", utr.Outcome);
        wfnn("testListId", utr.TestListId);

        wfnn("stdout", utr?.Output?.StdOut);
        wfnn("stderr", utr?.Output?.StdErr);
        wfnn("exceptionMessage", utr?.Output?.ErrorInfo?.Message);
        wfnn("exceptionStack", utr?.Output?.ErrorInfo?.StackTrace);
      } finally {
        popd();
      }
    }
    void extract(Times ts) {
      if (ts == null) { return; }

      wfnn("creationTime", ts.Creation);
      wfnn("queueingTime", ts.Queuing);
      wfnn("startTime", ts.Start);
      wfnn("finish", ts.Finish);
    }
    void extract(ResultSummary rs) {
      if (rs == null) { return; }
      extract(rs.Counters);
    }
    void extract(Counters cs) {
      if (cs == null) { return; }

      wfnz("total", cs.Total);
      wfnz("executed", cs.Executed);
      wfnz("passed", cs.Passed);
      wfnz("failed", cs.Failed);
      wfnz("timeout", cs.Timeout);
      wfnz("aborted", cs.Aborted);
      wfnz("inconclusive", cs.Inconclusive);
      wfnz("notRunnable", cs.NotRunnable);
      wfnz("disconnected", cs.Disconnected);
      wfnz("warning", cs.Warning);
      wfnz("notExecuted", cs.NotExecuted);
      wfnz("completed", cs.Completed);
      wfnz("inProgress", cs.InProgress);
      wfnz("pending", cs.Pending);
    }
  }

}
