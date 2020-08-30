using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    /// <summary>
    /// プラグインのパッケージ名
    /// </summary>
    private const string PLUGIN_PACKAGE_NAME = "com.reryka.calculation";

    /// <summary>
    /// クラス名
    /// </summary>
    private const string JAVA_CLASS_NAME = "MediaController";

    private const string PLAY_METHOD = "Play";
    private const string NEXT_PLAY_METHOD = "NextPlay";
    private const string STOP_METHOD = "Stop";

    static AndroidJavaObject plugin = null;

    [DllImport("__Internal")]
    private static extern void SetBackgroundMusic();

    [DllImport("__Internal")]
    private static extern void SetHello(string str);

    [DllImport("__Internal")]
    private static extern string GetHello();

    [DllImport("__Internal")]
    private static extern void PlayMusic(string path);

    [DllImport("__Internal")]
    private static extern void StopMusic();

    [SerializeField] private Text ResultText = default;

    private string[] names = { "EmptyDream.mid", "Mistletoe.mid", "Mistletoe_mix1.mid" };

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
            plugin = new AndroidJavaObject($"{PLUGIN_PACKAGE_NAME}.{JAVA_CLASS_NAME}");
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            SetBackgroundMusic();
    }
    
    public void OnClickPlayButton()
    {
        ResultText.text = "Click Play";

        if (Application.platform == RuntimePlatform.Android)
            CallPlay4Android();
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            CallPlay4IPhone();
    }

    private void CallPlay4Android()
    {
        try
        {
            bool result = false;

            plugin.Call<bool>(PLAY_METHOD, Application.persistentDataPath + "/" + names[0]);
            for (int i = 1; i < names.Length; i++)
                result = plugin.Call<bool>(NEXT_PLAY_METHOD, Application.persistentDataPath + "/" + names[i]);

            //bool result = plugin.Call<bool>(PLAY_METHOD);
            //bool result = plugin.Call<bool>(PLAY_METHOD, filePath);            

            if (result)
                ResultText.text = "Play!!";
            else
                ResultText.text = "Play Failure!!";
        }
        catch (Exception e)
        {
            CommandPanel.ShowError(e.ToString() + e.Message);
        }
    }

    private void CallPlay4IPhone()
    {
        string filePath = Application.streamingAssetsPath + "/EmptyDream.mid";

        //Hello();
        PlayMusic(filePath);

        SetHello(filePath);
        if (System.IO.File.Exists(filePath)) ResultText.text = "Exists!!\n";
        else ResultText.text = "Not found!!\n";

        ResultText.text += GetHello();
        //ResultText.text = "Play!!";
    }

    public void OnClickStopButton()
    {
        bool result =false;
        ResultText.text = "Click Stop";

        if (Application.platform == RuntimePlatform.Android)
            result = plugin.Call<bool>(STOP_METHOD);
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            StopMusic();

        if (result)
            ResultText.text = "Stop!!";
        else
            ResultText.text = "Stop Failure!!";
    }
}