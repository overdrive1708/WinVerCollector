[English](README.md) | [日本語](README.ja.md)

<h1 align="center">
    WinVerCollector
</h1>

<h2 align="center">
    Collect windows version.
</h2>

<div align="center">
    <img alt="csharp" src="https://img.shields.io/badge/csharp-blue.svg?style=plastic&logo=csharp">
    <img alt="dotnet" src="https://img.shields.io/badge/.NET-blue.svg?style=plastic&logo=dotnet">
    <img alt="license" src="https://img.shields.io/github/license/overdrive1708/WinVerCollector?style=plastic">
    <br>
    <img alt="repo size" src="https://img.shields.io/github/repo-size/overdrive1708/WinVerCollector?style=plastic&logo=github">
    <img alt="release" src="https://img.shields.io/github/release/overdrive1708/WinVerCollector?style=plastic&logo=github">
    <img alt="download" src="https://img.shields.io/github/downloads/overdrive1708/WinVerCollector/total?style=plastic&logo=github&color=brightgreen">
    <img alt="open issues" src="https://img.shields.io/github/issues-raw/overdrive1708/WinVerCollector?style=plastic&logo=github&color=brightgreen">
    <img alt="closed issues" src="https://img.shields.io/github/issues-closed-raw/overdrive1708/WinVerCollector?style=plastic&logo=github&color=brightgreen">
</div>

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
- [.NET Runtime 6.x.x](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Development environment
- Microsoft Visual Studio Community 2022
- .NET 6.0.300

## Libraries used
- CommandLineParser
- System.Data.SQLite.Core
- System.Management

Refer to "WinVerCollector.csproj" for version.

## Bug report & Feature request
Please report it via [Issue on GitHub](https://github.com/overdrive1708/WinVerCollector/issues/new/choose).

## License
This project is licensed under the MIT License.  
See [LICENSE](LICENSE) for details.

## Author.
[overdrive1708](https://github.com/overdrive1708)

## Changelog
See [CHANGELOG](CHANGELOG.md).
