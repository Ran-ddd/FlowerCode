using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 提供一个确认框 UI
public class ComfirmBox : MonoBehaviour
{
    [Header("文本UI")]
    public TMP_Text text;

    [Header("确认框输入")]
    public string description;
    public string function;
    public string[] inputs;

    //
    private Global global = Global.Instance;

    public void Show()
    {
        text.text = description;
    }

    // 根据不同的功能执行不同的操作
    public void Yes()
    {
        switch (function)
        {
            case "LoadScene":
                SceneManager.LoadScene(int.Parse(inputs[0]));
                break;
            default:
                throw new Exception("No Such ComfirmBox Function: " + function);
        }
        gameObject.SetActive(false);
    }

    // 关闭确认框
    public void No()
    {
        gameObject.SetActive(false);
    }
}
