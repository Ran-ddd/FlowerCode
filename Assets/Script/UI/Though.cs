using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Though : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textUI;

    [Header("资源")]
    public string though;

    [Header("滞留时间")]
    public float stayTime = 1f;

    // 全局单例
    private Global global = Global.Instance;


    public void Show()
    {
        CancelInvoke(nameof(Clear));
        textUI.text = though;
        Invoke(nameof(Clear), stayTime);
    }

    void Clear()
    {
        gameObject.SetActive(false);
    }
}