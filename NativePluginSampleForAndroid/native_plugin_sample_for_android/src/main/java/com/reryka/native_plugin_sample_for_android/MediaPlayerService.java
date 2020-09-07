package com.reryka.native_plugin_sample_for_android;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.media.MediaPlayer;
import android.media.PlaybackParams;
import android.media.RingtoneManager;
import android.net.Uri;

import com.unity3d.player.UnityPlayer;

public class MediaPlayerService{

    private static final String FILE_SCHEME = "file://";

    private static MediaPlayer player;

    public boolean Play() {
        player = new MediaPlayer();
        Uri uri = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);

        try {
            Activity activity = UnityPlayer.currentActivity;
            Context context = activity.getApplicationContext();
            player.setDataSource(context, uri);
            player.setLooping(true);
            player.prepare();
            player.start();
        } catch (Exception e) {
            e.getStackTrace();
        }

        return true;
    }

    public boolean Play(String filePath) {

        PlaybackParams params = new PlaybackParams();
        Uri uri = Uri.parse(FILE_SCHEME + filePath);

        try {
            Activity activity = UnityPlayer.currentActivity;
            Context context = activity.getApplicationContext();

            if (player == null)
                player = MediaPlayer.create(context, uri);

            player.setPlaybackParams(params.setSpeed(1.0001f));
            player.prepare();
            player.start();
            player.setPlaybackParams(params.setSpeed(1.0f));
        } catch (Exception e) {
            e.getStackTrace();
        }
        return true;
    }

    public boolean NextPlay(String filePath) {
        if (player == null)
            return false;

        try {
            PlaybackParams params = new PlaybackParams();

            Activity activity = UnityPlayer.currentActivity;
            Context context = activity.getApplicationContext();

            Uri uri = Uri.parse(FILE_SCHEME + filePath);

            MediaPlayer nextPlayer = MediaPlayer.create(context, uri);
            nextPlayer.setPlaybackParams(params.setSpeed(1.0001f));
            nextPlayer.prepare();
            player.setNextMediaPlayer(nextPlayer);
        } catch (Exception e) {
            e.getStackTrace();
        }
        return true;
    }

    public boolean SetSpeed(float speed) {
        PlaybackParams params = new PlaybackParams();
        params.setSpeed(speed);
        if (player != null)
            player.setPlaybackParams(params);
        return true;
    }

    public boolean Stop() {
        boolean result = true;
        try {
            Activity activity = UnityPlayer.currentActivity;
            Context context = activity.getApplicationContext();
            activity.stopService(new Intent(context, MediaPlayerService.class));
        } catch (Exception e) {
            result = false;
        }
        return result;
    }
}
