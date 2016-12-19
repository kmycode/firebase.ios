# firebase.ios

FirebaseのAuth、Database、StorageなどをXamarin.iOSから扱うためのNative Binding Libraryをビルドするためのプロジェクトを置いていきます。
本当はnugetパッケージで提供したかったのですが、Googleから断られました。。

## 使い方

1. [Firebase公式HP](https://firebase.google.com/?hl=ja) => ドキュメント => [iOSのスタートガイド](https://firebase.google.com/docs/ios/setup?hl=ja)で、ページ最後の「CocoaPods を使用せずに統合する」のところに、iOS向けFirebase SDKをzipでダウンロードできるリンクがありますので、それを落とします。解凍！
1. このリポジトリのファイルを全部ダウンロードします。クローンするなり、Download Zipするなりおまかせ
1. コマンドプロンプト起動し、カレントディレクトリをこのリポジトリに移動します
1. 右のコマンドを実行します：```copyfromgoogle "<Firebase iOS SDK folder>"``` 使用例: ```copyfromgoogle ..\firebase```
1. Firebase.iOS.slnをVisual Studioで起動して、Macと接続して各プロジェクトをビルドします。ビルドは必ず「Analytics」を最初にやります
1. ビルドしてできたDLLを、iOSアプリのプロジェクトに取り込みます
