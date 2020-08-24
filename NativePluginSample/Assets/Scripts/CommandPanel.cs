using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPanel : MonoBehaviour
{
    private static Text ResultText = default;
    private static GameObject instance = default;

    private void Start()
    {
        ResultText = transform.Find("Text").GetComponent<Text>();
        ResultText.text = string.Empty;
        gameObject.SetActive(false);
        instance = gameObject;
    }

    public static void ShowError(string message)
    {
        ResultText.text = message;
        instance.SetActive(true);
    }
}