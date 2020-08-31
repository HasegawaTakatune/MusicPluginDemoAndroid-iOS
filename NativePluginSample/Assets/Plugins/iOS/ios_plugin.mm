#import <UnityFramework/UnityFramework-Swift.h>

#ifdef __cplusplus
extern "C"{
#endif

// プラグインの流れ
// C# ━ Objective-c ━ swift
// このソースはC#とswiftを中継する役目

// バックグラウンド再生の設定
void SetBackgroundMusic(){
    [MusicController4iOS setBackgroundMusic];
}

// プラグインサンプル（引数あり）
void SetHello(const char *ch){
    NSString *str = [NSString stringWithCString:ch encoding:NSUTF8StringEncoding];
    [MusicController4iOS setHelloWithStr:str];
}

// プラグインサンプル（戻り値あり）
char* GetHello(){
    NSString* str = [MusicController4iOS getHello];
    
    const char *ch = (char *)[str UTF8String];
    char* retC = (char*)malloc(strlen(ch) + 1);
    strcpy(retC,ch);
    retC[strlen(ch)] = '\0';
    return retC;
}

// 引数で受け取ったファイルパスの曲再生
void PlayMusic(const char *ch){
    NSString *path = [NSString stringWithCString:ch encoding:NSUTF8StringEncoding];
    [MusicController4iOS playMusicWithPath:path];
}

// 曲停止
void StopMusic(){
    [MusicController4iOS stopMusic];
}

#ifdef __cplusplus
}
#endif
