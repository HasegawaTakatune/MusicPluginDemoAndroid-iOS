using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyTestScript : MonoBehaviour
{
    /// <summary>
    /// プラグインのパッケージ名
    /// </summary>
    private const string PLUGIN_PACKAGE_NAME = "com.reryka.calculation";

    /// <summary>
    /// クラス名
    /// </summary>
    private const string JAVA_CLASS_NAME = "NotifyTest";

    static AndroidJavaObject plugin = null;
    static GameObject instance = default;

    public void Awake()
    {
        instance = gameObject;
#if UNITY_ANDROID && !UNITY_EDITOR
        plugin = new AndroidJavaObject(PLUGIN_PACKAGE_NAME + JAVA_CLASS_NAME);
#endif
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Debug.Log("applicationWillResignActive or onPause");
#if UNITY_ANDROID && !UNITY_EDITOR
            plugin.Call("startService");
#endif
        }
        else
        {
            Debug.Log("applicationDidBecomeActive or onResume");
#if UNITY_ANDROID && !UNITY_EDITOR
            plugin.Call("stopService");
#endif
        }
    }
}
