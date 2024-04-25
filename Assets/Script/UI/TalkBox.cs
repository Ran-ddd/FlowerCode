using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TalkBox : MonoBehaviour
{
    [Header("UI")]
    public Image imageUI;
    public TMP_Text textUI;

    [Header("资源")]
    public Sprite playerHead;
    // NPC
    public string talker;
    public Sprite sprite;
    public TextAsset textAsset;

    // 全局单例
    private Global global = Global.Instance;

    // 对话管理
    private List<string> textList;
    private int index;
    private float speed = 0.05f;
    private bool textFinished;
    private bool cancelTyping;

    public void Show()
    {
        RenewTexts();
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textFinished && index >= textList.Count)
            {
                gameObject.SetActive(false);
            }
            else if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    void RenewTexts()
    {
        textList = new List<string>(textAsset.text.Split('\n'));
        index = 0;
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textUI.text = "";

        bool flag = true;
        while (flag && index < textList.Count)
        {
            Debug.Log(index);
            string[] cmds = textList[index].Trim().Split("-");
            Debug.Log(cmds[0]);
            switch (cmds[0])
            {
                case "<A>":
                    flag = false;
                    imageUI.sprite = playerHead;
                    break;
                case "<B>":
                    flag = false;
                    imageUI.sprite = sprite;
                    break;
                case "<C>":
                    global.NextProgress();
                    if (++index >= textList.Count) gameObject.SetActive(false);
                    break;
                case "<D>":
                    TriggerEvent(cmds.Skip(1).ToArray());
                    if (++index >= textList.Count) gameObject.SetActive(false);
                    break;
            }
            index++;
        }

        if (index >= textList.Count)
        {
            textFinished = true;
            yield break;
        }

        for (int i = 0; !cancelTyping && i < textList[index].Length; i++)
        {
            textUI.text += textList[index][i];
            yield return new WaitForSeconds(speed);
        }

        textUI.text = textList[index];
        index++;
        cancelTyping = false;
        textFinished = true;
    }

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
            default:
                throw new System.Exception("Invalid Text Command: " + "<D>-" + string.Join("-", inputs));
        }
    }
}