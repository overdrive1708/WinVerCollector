[English](README.md) | [日本語](README.ja.md)

# WinVerCollector

Windowsバージョン情報収集アプリ

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

## 必要要件
- [.NET ランタイム 6.0.5](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## 開発環境
- Microsoft Visual Studio Community 2022
- .NET 6.0.300

## 使用しているライブラリ
- CommandLineParser(Version.2.9.1)
- System.Data.SQLite.Core(Version.1.0.116)
- System.Management(Version.6.0.0)

## ライセンス
このプロジェクトはMITライセンスです。  
詳細は [LICENSE](LICENSE) を参照してください。

## 作者
[overdrive1708](https://github.com/overdrive1708)

## 変更履歴
[CHANGELOG](CHANGELOG.md)を参照してください｡
