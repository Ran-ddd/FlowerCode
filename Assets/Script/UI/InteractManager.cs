using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    // 全局单例
    private Global global = Global.Instance;

    [Header("激活蒙版的 UI")]
    public List<GameObject> activeMaskUIs;

    [Header("蒙版")]
    public GameObject mask;

    [Header("对话框")]
    public GameObject talkBoxUI;
    private TalkBox talkBox;

    [Header("物品框")]
    public GameObject itemInfoUI;
    private ItemInfo itemInfo;

    [Header("背包")]
    public GameObject bagUI;
    private Bag bag;

    [Header("背包物品")]
    public GameObject packItemInfoUI;
    private PackItemInfo packItemInfo;

    [Header("自言自语")]
    public GameObject thoughUI;
    private Though though;

    [Header("确认框")]
    public GameObject comfirmBoxUI;
    private ComfirmBox comfirmBox;


    void Start()
    {
        // UI
        itemInfo = itemInfoUI.GetComponent<ItemInfo>();
        talkBox = talkBoxUI.GetComponent<TalkBox>();
        packItemInfo = packItemInfoUI.GetComponent<PackItemInfo>();
        bag = bagUI.GetComponent<Bag>();
        though = thoughUI.GetComponent<Though>();
        comfirmBox = comfirmBoxUI.GetComponent<ComfirmBox>();

        // 暴露给全局的 UI 显示接口
        global.UseUI += UseUI;
    }

    void OnDisable()
    {
        // 记得删除
        global.UseUI -= UseUI;
    }

    void Update()
    {
        mask.SetActive(activeMaskUIs.Any(ui => ui.activeSelf));
    }

    public void UseUI(string choice, params string[] parameters)
    {
        switch (choice)
        {
            case "Item":
                UseItemInfoUI(parameters[0]);
                break;
            case "Talk":
                UseTalkBoxUI(parameters[0]);
                break;
            case "PackItem":
                UsePackItemInfoUI(parameters[0]);
                break;
            case "Bag":
                UseBagUI();
                break;
            case "Though":
                UseThoughUI(parameters[0], float.Parse(parameters[1]));
                break;
            case "Comfirm":
                UseComfirmBoxUI(parameters[0], parameters[1], parameters.Skip(2).ToArray());
                break;
            default:
                throw new Exception("Invalid UseUI Choice: " + choice);
        }
    }

    private void UseItemInfoUI(string itemName)
    {
        itemInfoUI.SetActive(true);
        itemInfo.sprite = global.LoadItemSpite(itemName);
        itemInfo.textAsset = global.LoadItemTextAsset(itemName);
        itemInfo.Show();
    }

    private void UseTalkBoxUI(string talkerName)
    {
        talkBoxUI.SetActive(true);
        talkBox.sprite = global.LoadCharacterHeadSpite(talkerName);
        talkBox.textAsset = global.LoadCharacterTextAsset(talkerName);
        Debug.Log(talkBox.textAsset);
        talkBox.Show();
    }

    public void UsePackItemInfoUI(string itemName)
    {
        packItemInfoUI.SetActive(true);
        packItemInfo.textAsset = global.LoadItemTextAsset(itemName);
        packItemInfo.Show();
    }

    public void UseBagUI()
    {
        bag.TooglePack();
    }

    public void UseThoughUI(string word, float stayTime)
    {
        thoughUI.SetActive(true);
        though.though = word;
        though.stayTime = stayTime;
        though.Show();
    }

    public void UseComfirmBoxUI(string description, string function, string[] inputs)
    {
        comfirmBoxUI.SetActive(true);
        comfirmBox.description = description;
        comfirmBox.function = function;
        comfirmBox.inputs = inputs;
        comfirmBox.Show();
    }
}
