# TRXParser

This is a very lightweight and low level library for parsing trx files (the ones that are created by the mstest unit test runner). It provides some basic functions to read and write a valid trx object model.


## Credits

The object model was initially sourced from [https://github.com/rndsolutions/trx-merger] but has largely been reworked as well. This code is being released under an apache license like that source project, just in case there is any concerns.

## Usage

Reading:

```csharp
using TrxTools.TrxParser;

/// ... class / method

using (var inStream = File.OpenRead(filename)) {
  var objectModel = TrxControl.ReadTrx(inStream);
}
```

Writing is equally easy:


```csharp
using TrxTools.TrxParser;

/// ... class / method

using (var outstream = File.OpenWrite(filename)) {
    TrxControl.WriteTrx(objectModel, outstream);
}
```

# Release Notes

[For Release Notes See Here](trxparser.releaseNotes.md)

