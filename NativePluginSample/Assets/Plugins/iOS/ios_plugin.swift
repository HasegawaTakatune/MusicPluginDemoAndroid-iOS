import Foundation
import AVFoundation

@objc public class Sample:NSObject{
    
    private static var show:String = "";
    private static var musicPlayer : MusicPlayer?;
    private static var sequence : MusicSequence?;
    
    @objc public static func hello(){
        //print("Hello Swift");
    }
    
    @objc public static func setHello(str:String){
        if(FileManager.default.fileExists(atPath:str)){
            show.append("Exists this file path!!\n");
        }
        show.append(str);
        show.append("\n");
    }
    
    @objc public static func getHello() -> String{
        show.append("\nHello Swift");
        return show;
    }
    
    @objc public static func playMusic(path:String){
        let midiFile = URL(fileURLWithPath: path)//Bundle.main.url(forResource: path, withExtension: "mid");
        NewMusicPlayer(&musicPlayer);
        NewMusicSequence(&sequence);
        
        print("File >>");
        print(midiFile);
        print(path);
        
        if let musicPlayer = musicPlayer, let sequence = sequence {
            MusicSequenceFileLoad(sequence, midiFile as! CFURL, .midiType, MusicSequenceLoadFlags());
            MusicPlayerSetSequence(musicPlayer, sequence);
            MusicPlayerStart(musicPlayer);
        }
    }
    
    @objc public static func stopMusic(){
//        musicPlayer.stop();
    }
}
