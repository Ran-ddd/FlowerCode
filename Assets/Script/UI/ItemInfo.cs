using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    [Header("UI")]
    public Image imageUI;
    public TMP_Text textUI;

    [Header("资源")]
    public Sprite sprite;
    public TextAsset textAsset;

    // 全局单例 
    private Global global = Global.Instance;

    // 清除后执行的指令
    private string[] cmds;

    // 显示物品信息，图片+文字
    public void Show()
    {
        imageUI.sprite = sprite;

        List<string> textList = new(textAsset.text.Split('\n'));
        // 遍历textList
        string text = "";
        for (int i = 0; i < textList.Count; i++)
        {
            if (textList[i].StartsWith("<C>"))
            {
                Global.Instance.NextProgress();
            }
            else if (textList[i].StartsWith("<D>"))
            {
                cmds = textList[i].Split("-").Skip(1).ToArray();
            }
            else
            {
                text += textList[i] + "\n";
            }
        }
        textUI.text = text.Trim();
    }

    // 物品中的 <D> 指令
    void TriggerEvent(string[] inputs)
    {
        string cmd = inputs[0];
        string[] parameters = inputs.Skip(1).ToArray();
        Debug.Log(cmd);
        switch (cmd)
        {
            case "LoadScene":
                SceneManager.LoadScene(int.Parse(parameters[0]));
                break;
            case "UseUI":
                global.UseUI(parameters[0], parameters.Skip(1).ToArray());
                break;
            case "CollectItem":
                global.collectedItems.Add(parameters[0]);
                break;
            default:
                throw new System.Exception("Invalid Text Command: " + "<D>-" + string.Join("-", inputs));
        }
    }

    // 关闭物品信息
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cmds != null)
            {
                TriggerEvent(cmds);
            }
            gameObject.SetActive(false);
        }
    }
}
