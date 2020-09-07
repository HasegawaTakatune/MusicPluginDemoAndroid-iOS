package com.reryka.native_plugin_sample_for_android;

import android.app.IntentService;
import android.content.Intent;
import android.media.MediaPlayer;
import android.media.RingtoneManager;
import android.net.Uri;

public class MediaPlayerService extends IntentService {

    private MediaPlayer player;

    public MediaPlayerService(String name) {
        super(name);
    }

    public MediaPlayerService() {
        super("MediaPlayerService");
    }

//    public  static  void  startAction

    @Override
    public void onHandleIntent(Intent intent) {

//        AudioManager manager = (AudioManager) getSystemService(MediaPlayerService.this.AUDIO_SERVICE);
//        manager.setStreamVolume(AudioManager.STREAM_MUSIC,
//                manager.getStreamMaxVolume(AudioManager.STREAM_MUSIC),
//                AudioManager.FLAG_SHOW_UI);

        player = new MediaPlayer();
        Uri uri = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
        String bgmUri = "android.resource://" + getPackageName() + "/" + R.raw.intersection1;
        uri = Uri.parse(bgmUri);

        try {
            player.setDataSource(MediaPlayerService.this, uri);
            player.setLooping(true);
            player.prepare();
            player.start();
        } catch (Exception e) {
            e.getStackTrace();
        }
    }

    @Override
    public void onDestroy() {
        if (player.isPlaying()) {
            player.stop();
        }
        player.release();
        player = null;

        super.onDestroy();
    }
}
