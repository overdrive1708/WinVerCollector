[English](README.md) | [日本語](README.ja.md)

# WinVerCollector

Collect windows version.

## Usage
```
WinVerCollector.exe [options]
options:[-coqsv] [--output] [--show] [--clean] [--quiet] [--verbose] [--help] [--version]
  -o, --output    Output collected windows version info.

  -s, --show      Display collected windows version info.

  -c, --clean     Clean database.

  -q, --quiet     Do not display processing results.

  -v, --verbose   Display windows version info.

  --help          Display this help screen.

  --version       Display version information.
```
### Collect windows version
```
WinVerCollector.exe
```
Create "DeviceInfo.db" file and storead collect data.
### Output csv file
```
WinVerCollector.exe -o
```
Output "DeviceInfo.csv" file.

## Requirements
- [.NET Runtime 6.0.5](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Development environment
- Microsoft Visual Studio Community 2022
- .NET 6.0.300

## Libraries used
- CommandLineParser(Version.2.9.1)
- System.Data.SQLite.Core(Version.1.0.116)
- System.Management(Version.6.0.0)

## License
This project is licensed under the MIT License.  
See [LICENSE](LICENSE) for details.

## Author.
[overdrive1708](https://github.com/overdrive1708)

## Changelog
See [CHANGELOG](CHANGELOG.md).
