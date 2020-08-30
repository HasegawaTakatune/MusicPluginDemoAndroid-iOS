#import <UnityFramework/UnityFramework-Swift.h>

#ifdef __cplusplus
extern "C"{
#endif
void SetBackgroundMusic(){
    [MusicController4iOS setBackgroundMusic];
}

void SetHello(const char *ch){
    NSString *str = [NSString stringWithCString:ch encoding:NSUTF8StringEncoding];
    [MusicController4iOS setHelloWithStr:str];
}

char* GetHello(){
    NSString* str = [MusicController4iOS getHello];
    
    const char *ch = (char *)[str UTF8String];
    char* retC = (char*)malloc(strlen(ch) + 1);
    strcpy(retC,ch);
    retC[strlen(ch)] = '\0';
    return retC;
}

void PlayMusic(const char *ch){
    NSString *path = [NSString stringWithCString:ch encoding:NSUTF8StringEncoding];
    [MusicController4iOS playMusicWithPath:path];
}

void StopMusic(){
    [MusicController4iOS stopMusic];
}

#ifdef __cplusplus
}
#endif
