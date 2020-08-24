package com.reryka.android_plugin;

import android.app.IntentService;
import android.content.Intent;
import android.util.Log;

public class NotifyIntentService extends IntentService {
    public static volatile boolean shouldContinue = true;

    public NotifyIntentService(String name) {
        super(name);
    }

    public NotifyIntentService() {
        super("NotifyIntentService");
    }

    @Override
    protected void onHandleIntent(Intent intent) {
        final String tag = "NotifyIntentService";
        shouldContinue = true;

        Log.d(tag, "onHandleIntent Start");

        long endTime = System.currentTimeMillis() + 60 * 1000;
        while (System.currentTimeMillis() < endTime) {
            Log.d(tag, "onHandleIntent " + String.valueOf(endTime));
            synchronized (this) {
                try {
                    wait(endTime - System.currentTimeMillis());
                    if (!shouldContinue) {
                        stopSelf();
                        return;
                    }

                    NotifyTest notifyTest = new NotifyTest();
                    notifyTest.sendNotification();
                } catch (Exception e) {

                }
            }
        }
    }
}