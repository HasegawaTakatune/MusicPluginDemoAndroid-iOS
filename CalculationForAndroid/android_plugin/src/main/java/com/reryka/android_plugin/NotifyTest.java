package com.reryka.android_plugin;


import android.app.Activity;
import android.content.Context;
import android.content.Intent;

import com.unity3d.player.UnityPlayer;

public class NotifyTest {

    public void startService() {
        Activity activity = UnityPlayer.currentActivity;
        Context context = activity.getApplicationContext();
        activity.startService(new Intent(context, NotifyIntentService.class));
    }

    public void stopService() {
        NotifyIntentService.shouldContinue = false;
    }

    public void sendNotification() {
        //NotifyIntentService.shouldContinue = true;
    }
}
