#import <UnityFramework/UnityFramework-Swift.h>

#ifdef __cplusplus
extern "C"{
#endif
void Hello(){
    [Sample hello];
}

void SetHello(const char *ch){
    NSString *str = [NSString stringWithCString:ch encoding:NSUTF8StringEncoding];
    [Sample setHelloWithStr:str];
}

char* GetHello(){
    NSString* str = [Sample getHello];
    
    const char *ch = (char *)[str UTF8String];
    char* retC = (char*)malloc(strlen(ch) + 1);
    strcpy(retC,ch);
    retC[strlen(ch)] = '\0';
    return retC;
}

void PlayMusic(const char *ch){
    NSString *path = [NSString stringWithCString:ch encoding:NSUTF8StringEncoding];
    [Sample playMusicWithPath:path];
}

void StopMusic(){
    [Sample stopMusic];
}

#ifdef __cplusplus
}
#endif
