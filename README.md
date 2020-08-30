![Source Code Size](https://img.shields.io/github/languages/code-size/HasegawaTakatune/MusicPluginDemoAndroid-iOS)  
  
# MusicPluginDemoAndroid-iOS  
  
# 概要  
 Unityを使いAndroid/iOSプラグインを経由した曲生成とバックグラウンド再生の実装デモ  

# 説明  
 プラグインの作成→各言語で曲再生の処理を追加→必要な場合はバックグラウンド再生を加える  
 趣味でMIDIを使うことが多いのでMIDI再生を実装している。その場合でも標準の曲再生の処理
 を使い、リソース取得の部分だけURL参照で直接MIDIファイルを取得している。  
   
 **注意  
 iOSでバックグラウンド再生を行う場合はUnityでビルドして生成されるXcodeプロジェクトで  
 設定をおこな分ければいけない（下記参照）その手順を忘れずに行ってください。**  
  
# 参照  
- MIDI音源  
[フリーMIDI／MP3のフリーダウンロード ｜ MIFUNO STUDIO](http://www.mifunostudio.com/freemidimp3/)  
  
### Android版  
- プラグインの実装  
[Unity向けAndroidネイティブプラグインの作り方](https://gaprot.jp/2020/03/30/unity-android-native-plugin/)  
- Androidで曲再生  
[[Android]簡単なMediaPlayerで音楽を再生する](https://akira-watson.com/android/audio-player.html)  
  
### iOS版  
- プラグインの実装  
[UnityのiOSプラグインの作成](https://note.com/npaka/n/nc6236cde60c1)  
- Swiftで曲再生  
[SwiftでMIDIファイルを再生する方法](https://develop.hateblo.jp/entry/swift-midi-player)  
- バックグラウンド再生の設定  
[[Swift4]バックグラウンドでオーディオ再生する](https://qiita.com/kenny_J_7/items/936d91151149868618a8)  
  
# 環境  
- Unity 2019.3.13f1  
- Visual Studio 2019  
- Android Studio 3.6.2  
- Xcode 11.6  
  
# 言語  
- C#  
- Java  
- Swift5  
