using System;
using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private Text ResultText = default;

    private void Start()
    {
        plugin = new AndroidJavaObject($"{PLUGIN_PACKAGE_NAME}.{JAVA_CLASS_NAME}");
    }

    public void OnClickPlayButton()
    {
        ResultText.text = "Click Play";
        try
        {
            string[] names = { "EmptyDream.mid", "Mistletoe.mid", "Mistletoe_mix1.mid" };
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

    public void OnClickStopButton()
    {
        ResultText.text = "Click Stop";
        bool result = plugin.Call<bool>(STOP_METHOD);
        if (result)
            ResultText.text = "Stop!!";
        else
            ResultText.text = "Stop Failure!!";
    }
}