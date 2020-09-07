using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 曲再生コントローラ
/// </summary>
public class MusicController : MonoBehaviour
{
    /// <summary>
    /// プラグインのパッケージ名
    /// </summary>
    //private const string PLUGIN_PACKAGE_NAME = "com.reryka.calculation";
    private const string PLUGIN_PACKAGE_NAME = "com.reryka.native_plugin_sample_for_android";

    /// <summary>
    /// クラス名
    /// </summary>
    //private const string JAVA_CLASS_NAME = "MediaController";
    private const string JAVA_CLASS_NAME = "MediaPlayerService";

    /// <summary>
    /// Androidプラグインメソッド名：曲再生
    /// </summary>
    private const string PLAY_METHOD = "Play";
    /// <summary>
    /// Androidプラグインメソッド名：次曲再生
    /// </summary>
    private const string NEXT_PLAY_METHOD = "NextPlay";
    /// <summary>
    /// Androidプラグインメソッド名：停止
    /// </summary>
    private const string STOP_METHOD = "Stop";

    /// <summary>
    /// Android用のプラグインインスタンス
    /// </summary>
    static AndroidJavaObject plugin = null;

    /// <summary>
    /// iOS用のプラグインメソッド：バックグラウンド再生の設定
    /// </summary>
    [DllImport("__Internal")]
    private static extern void SetBackgroundMusic();
    /// <summary>
    /// iOS用のプラグインメソッド：テストプラグイン文字列の設定
    /// </summary>
    /// <param name="str">設定する文字列</param>
    [DllImport("__Internal")]
    private static extern void SetHello(string str);
    /// <summary>
    /// iOS用のプラグインメソッド：テストプラグイン文字列の取得
    /// </summary>
    /// <returns>設定した文字列を取得</returns>
    [DllImport("__Internal")]
    private static extern string GetHello();
    /// <summary>
    /// iOS用のプラグインメソッド：曲再生
    /// </summary>
    /// <param name="path">再生曲のファイルパス</param>
    [DllImport("__Internal")]
    private static extern void PlayMusic(string path);
    /// <summary>
    /// iOS用のプラグインメソッド：曲停止
    /// </summary>
    [DllImport("__Internal")]
    private static extern void StopMusic();

    /// <summary>
    /// 実行結果表示テキスト
    /// </summary>
    [SerializeField] private Text ResultText = default;

    /// <summary>
    /// 曲ファイル名
    /// </summary>
    private string[] names = { "EmptyDream.mid", "Mistletoe.mid", "Mistletoe_mix1.mid" };

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Start()
    {       
        if (Application.platform == RuntimePlatform.Android)
        {
            // Javaプラグインクラス取得
            plugin = new AndroidJavaObject($"{PLUGIN_PACKAGE_NAME}.{JAVA_CLASS_NAME}");
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            // iOSバックグラウンド再生設定
            SetBackgroundMusic();
        }
    }

    /// <summary>
    /// 再生ボタンイベント
    /// </summary>
    public void OnClickPlayButton()
    {
        ResultText.text = "Click Play";

        // プラットフォーム別に曲再生イベント実行
        if (Application.platform == RuntimePlatform.Android)
            CallPlay4Android();
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
            CallPlay4IPhone();
    }

    /// <summary>
    /// Android用曲再生メソッドの呼び出し
    /// </summary>
    private void CallPlay4Android()
    {
        try
        {
            bool result = false;

            // 曲ファイルのパスを渡して再生
            plugin.Call<bool>(PLAY_METHOD, Application.persistentDataPath + "/" + names[0]);
            //for (int i = 1; i < names.Length; i++)
            //    result = plugin.Call<bool>(NEXT_PLAY_METHOD, Application.persistentDataPath + "/" + names[i]);

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

    /// <summary>
    /// iOS用曲再生メソッドの呼び出し
    /// </summary>
    private void CallPlay4IPhone()
    {
        ResultText.text = "Play!!";

        // 曲のパス指定して再生
        string filePath = Application.streamingAssetsPath + "/EmptyDream.mid";
        PlayMusic(filePath);

        if (System.IO.File.Exists(filePath)) ResultText.text = "Exists!!\n";
        else ResultText.text = "Not found!!\n";
    }

    /// <summary>
    /// 停止ボタンイベント
    /// </summary>
    public void OnClickStopButton()
    {
        bool result =false;       

        // 曲停止メソッドの呼び出し
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