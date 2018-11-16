# TRX Filesystem
Extract a trx file into constituent parts on the local fileystem. This is a one-way operation to take a massive TRX file consisting of 100s or 1000s of unit tests and breaking the file down into smaller files that are more easily analyzed.

This package is available on nuget at: https://www.nuget.org/packages/trxfilesystem

The source for this package is available on github at: https://github.com/hannasm/TRXToolsDotNet/tree/master/trxfilesystem/

# Usage
Usage: extracttrx [-f <filename>]+ -d <destination>
Extract trx file into constituent pieces inside filesystem

  -h, --help                 show help message
  -f, --file=VALUE           The file to extract
  -d, --destination=VALUE    The directory to extract into
