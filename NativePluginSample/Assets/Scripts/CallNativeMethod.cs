using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallNativeMethod : MonoBehaviour
{
    /// <summary>
    /// 結果表示
    /// </summary>
    private Text result;

    /// <summary>
    /// プラグイン側の計算クラスインスタンス
    /// </summary>
    private AndroidJavaObject _calculator;

    /// <summary>
    /// プラグインのパッケージ名
    /// </summary>
    private const string PLUGIN_PACKAGE_NAME = "com.reryka.calculation";

    /// <summary>
    /// Javaの計算クラス名
    /// </summary>
    private const string JAVA_CLASS_NAME = "NativeCalculatorForAndroid";

    /// <summary>
    /// プラグイン側の足し算メソッド名
    /// </summary>
    private const string ADD_METHOD = "Add";

    private const string SUBTRACT_METHOD = "Subtract";

    private const string MULTIPLY_METHOD = "Multiply";

    private const string DIVIDE_METHOD = "Divide";

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
#if UNITY_ANDROID
        CallMethod();
#endif
    }

    private void CallMethod()
    {
        float value = 0.0f;
        string method = string.Empty;

        result = GetComponent<Text>();
        result.text = "";

        _calculator = new AndroidJavaObject($"{PLUGIN_PACKAGE_NAME}.{JAVA_CLASS_NAME}", gameObject.name);

        method = ADD_METHOD;
        value = 5.0f;
        result.text += method + " : " + _calculator.Call<float>(method, value) + "\n";
        value = 4.0f;
        result.text += method + " : " + _calculator.Call<float>(method, value) + "\n";
        value = 3.0f;
        result.text += method + " : " + _calculator.Call<float>(method, value) + "\n";

        method = SUBTRACT_METHOD;
        value = 1.0f;
        result.text += method + " : " + _calculator.Call<float>(method, value) + "\n";
        value = 2.0f;
        result.text += method + " : " + _calculator.Call<float>(method, value) + "\n";
        value = 3.0f;
        result.text += method + " : " + _calculator.Call<float>(method, value) + "\n";

        method = MULTIPLY_METHOD;
        value = 2;
        _calculator.Call(method, value, "onCompleteCalc");

        method = DIVIDE_METHOD;
        value = 3;
        try
        {
            _calculator.Call(method, value, "onCompleteCalc");
        }
        catch (Exception e)
        {
            result.text += e.Message + "\n";
        }
    }

    private void OnDestroy()
    {
        _calculator?.Dispose();
        _calculator = null;
    }

    private void onCompleteCalc(string value)
    {
        float number = float.Parse(value);
        result.text += "onCompleteCalc : " + number + "\n";
    }
}
