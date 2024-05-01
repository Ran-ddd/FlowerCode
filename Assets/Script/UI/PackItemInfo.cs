using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PackItemInfo : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text textUI;

    [Header("资源")]
    public TextAsset textAsset;

    // 在背包的显示栏 显示物品信息，文字
    public void Show()
    {
        textUI.text = textAsset.text.Split('\n').Last();
    }
}