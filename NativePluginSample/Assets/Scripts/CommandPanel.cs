using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// コマンド表示の制御
/// </summary>
public class CommandPanel : MonoBehaviour
{
    /// <summary>
    /// 表示テキスト
    /// </summary>
    private static Text ResultText = default;
    /// <summary>
    /// インスタンス保持
    /// </summary>
    private static GameObject instance = default;

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Start()
    {
        ResultText = transform.Find("Text").GetComponent<Text>();
        ResultText.text = string.Empty;
        gameObject.SetActive(false);
        instance = gameObject;
    }

    /// <summary>
    /// エラー表示
    /// </summary>
    /// <param name="message">メッセージ</param>
    public static void ShowError(string message)
    {
        ResultText.text = message;
        instance.SetActive(true);
    }
}