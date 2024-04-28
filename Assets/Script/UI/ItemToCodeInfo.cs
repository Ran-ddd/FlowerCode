using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemToCodeInfo : MonoBehaviour
{
    [Header("UI")]
    public Image itemImageUI;
    public Image codeImageUI;
    public TMP_Text textUI;

    [Header("资源")]
    public Sprite itemSprite;
    public Sprite codeSprite;
    public TextAsset textAsset;

    [Header("出现速度")]
    public float speed = 0.01f;

    public void Show()
    {
        itemImageUI.sprite = itemSprite;
        codeImageUI.sprite = codeSprite;
        List<string> textList = new(textAsset.text.Split('\n'));
        if (textList[0].Trim() == "<C>")
        {
            Global.Instance.NextProgress();
            textUI.text = textList.Skip(1).Aggregate((a, b) => a + "\n" + b);
        }
        else
        {
            textUI.text = textAsset.text;
        }

        StartCoroutine(ShowCode());
    }

    IEnumerator ShowCode()
    {
        codeImageUI.color = new Color(1, 1, 1, 0);
        for (float i = 0; i <= 1; i += speed)
        {
            codeImageUI.color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
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
