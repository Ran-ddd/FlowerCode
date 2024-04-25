using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    [Header("UI")]
    public Image imageUI;
    public TMP_Text textUI;

    [Header("资源")]
    public Sprite sprite;
    public TextAsset textAsset;

    public void Show()
    {
        imageUI.sprite = sprite;

        List<string> textList = new(textAsset.text.Split('\n'));
        if (textList[0].Trim() == "<C>")
        {
            Global.Instance.NextProgress();
            textUI.text = textList[1];
        }
        else
        {
            textUI.text = textList[0];
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
}
