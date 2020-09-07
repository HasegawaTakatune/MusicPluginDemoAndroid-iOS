package com.reryka.native_plugin_sample_for_android;

import com.unity3d.player.UnityPlayer;

public class NativeCalculatorForAndroid {

    /**
     *     Unity側のGameObject名
      */
    private  String _gameObjectName;

    /**
     * 最終計算結果
     */
    private float _lastResult = 0;

    /**
     * コンストラクタ
     * @param gameObjectName Unity側のGameObject名
     */
    public  NativeCalculatorForAndroid(String gameObjectName)
    {
        _lastResult = 0;
        _gameObjectName = gameObjectName;
    }

    /**
     * @param value 足す値
     * @return 計算結果
     */
    public float Add(float value)
    {
        _lastResult += value;
        return _lastResult;
    }

    /**
     * @param value 引く値
     * @return 計算結果
     */
    public  float Subtract(float value)
    {
        _lastResult -= value;
        return _lastResult;
    }

    /**
     * @param value 割る値
     * @param onComplete 計算結果を返すメソッド名
     */
    public void Multiply(float value,String onComplete)
    {
        _lastResult *= value;
        UnityPlayer.UnitySendMessage(_gameObjectName,onComplete,String.valueOf(_lastResult));
    }

    /**
     * @param value 割る値
     * @param onComplete 計算結果を返すメソッド名
     * @throws Exception 0徐算の例外
     */
    public void Divide(float value,String onComplete) throws Exception
    {
        if(value == 0)
        {
            throw new Exception("0では割れません");
        }
        _lastResult /= value;
        UnityPlayer.UnitySendMessage(_gameObjectName,onComplete,String.valueOf(_lastResult));
    }
}
