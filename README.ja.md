[English](README.md) | [日本語](README.ja.md)

<h1 align="center">
    WinVerCollector
</h1>

<h2 align="center">
    Windowsバージョン情報収集アプリ
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

## 使用方法
```
WinVerCollector.exe [options]
options:[-coqsv] [--output] [--show] [--clean] [--quiet] [--verbose] [--help] [--version]
  -o, --output     収集結果をCSVファイルに出力します.

  -s, --show       収集結果を表示します.

  -c, --clean      データベースをクリーンアップします.

  -q, --quiet      処理の結果を表示しません(サイレントモード).

  -v, --verbose    処理の結果を詳細に表示します.

  --help          このアプリのヘルプを表示します.

  --version       このアプリのバージョン情報を表示します.
```
### Windowsバージョン情報の収集
```
WinVerCollector.exe
```
"DeviceInfo.db"ファイルが生成され､収集データが蓄積されます｡

### 収集結果のCSV出力
```
WinVerCollector.exe -o
```
収集データが"DeviceInfo.csv"ファイルに出力されます｡

## サポートするOSバージョン
- Windows10
  - Version 1507
  - Version 1511
  - Version 1607
  - Version 1703
  - Version 1709
  - Version 1803
  - Version 1809
  - Version 1903
  - Version 1909
  - Version 2004
  - Version 20H2
  - Version 21H1
  - Version 21H2
- Windows11
  - Version 21H2
  - Version 22H2

## 必要要件
- [.NET ランタイム 6.x.x](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## 開発環境
- Microsoft Visual Studio Community 2022
- .NET 6.0.300

## 使用しているライブラリ
- CommandLineParser
- System.Data.SQLite.Core
- System.Management

バージョンは"WinVerCollector.csproj"を参照してください｡

## ライセンス
このプロジェクトはMITライセンスです。  
詳細は [LICENSE](LICENSE) を参照してください。

## 不具合報告と機能要望
[GitHubのIssue](https://github.com/overdrive1708/WinVerCollector/issues/new/choose)より報告してください｡

## 作者
[overdrive1708](https://github.com/overdrive1708)

## 変更履歴
[CHANGELOG](CHANGELOG.md)を参照してください｡
