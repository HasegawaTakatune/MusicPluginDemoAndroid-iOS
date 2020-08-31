import Foundation
import AVFoundation

// プラグインの流れ
// C# ━ Objective-c ━ swift
// このソースはswiftでiOS特有の処理を行う役目
@objc public class MusicController4iOS:NSObject{
    
    // プラグインの引数保持と戻り値用
    private static var show:String = "";
    // ミュージックプレイヤ
    private static var musicPlayer : MusicPlayer?;
    // シーケンサ
    private static var sequence : MusicSequence?;
    // セッション
    private static let session = AVAudioSession.sharedInstance();
    
    // バックグラウンド再生設定
    @objc public static func setBackgroundMusic(){
        // カテゴリ設定
        do{
            try session.setCategory(AVAudioSession.Category.playback)
        }catch{
            fatalError("カテゴリ設定失敗");
        }
        
        // セッション有効化
        do{
            try session.setActive(true);
        }catch{
            fatalError("session有効化失敗");
        }
    }
    
    // 引数ありプラグインサンプル
    @objc public static func setHello(str:String){
        if(FileManager.default.fileExists(atPath:str)){
            show.append("Exists this file path!!\n");
        }
        show.append(str);
        show.append("\n");
    }
    
    // 戻り値ありプラグインサンプル
    @objc public static func getHello() -> String{
        show.append("\nHello Swift");
        return show;
    }
    
    // パス指定曲再生
    @objc public static func playMusic(path:String){
        // URLから曲ファイル取得
        let midiFile = URL(fileURLWithPath: path);
        // インスタンス取得
        NewMusicPlayer(&musicPlayer);
        NewMusicSequence(&sequence);
        
        if let musicPlayer = musicPlayer, let sequence = sequence {
            // 曲読み込み
            MusicSequenceFileLoad(sequence, midiFile as! CFURL, .midiType, MusicSequenceLoadFlags());
            MusicPlayerSetSequence(musicPlayer, sequence);
            // 曲再生
            MusicPlayerStart(musicPlayer);
        }
    }
    
    // 曲停止
    @objc public static func stopMusic(){
        if let musicPlayer = musicPlayer, let sequence = sequence {
            MusicPlayerStop(musicPlayer);
        }
    }
}
