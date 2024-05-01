using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// 统一的 UI 管理器
// 提供一个全局的 UI 使用接口
// 统一获取资源再提供给UI，简化其他脚本的资源获取

public class InteractManager : MonoBehaviour
{
    // 全局单例
    private Global global = Global.Instance;

    // 用于位置锁定，防止使用 UI 时角色乱跑
    private Transform playerTarget;
    private Transform player;

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

    [Header("物码框")]
    public GameObject itemToCodeInfoUI;
    private ItemToCodeInfo itemToCodeInfo;


    void Start()
    {
        // UI
        itemInfo = itemInfoUI.GetComponent<ItemInfo>();
        talkBox = talkBoxUI.GetComponent<TalkBox>();
        packItemInfo = packItemInfoUI.GetComponent<PackItemInfo>();
        bag = bagUI.GetComponent<Bag>();
        though = thoughUI.GetComponent<Though>();
        comfirmBox = comfirmBoxUI.GetComponent<ComfirmBox>();
        itemToCodeInfo = itemToCodeInfoUI.GetComponent<ItemToCodeInfo>();

        // 位移
        playerTarget = GameObject.FindGameObjectWithTag("PlayerTarget").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;

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
        PreventClick();
    }

    // 防止点击时角色乱跑
    void PreventClick()
    {
        if (activeMaskUIs.Any(ui => ui.activeSelf))
        {
            playerTarget.position = player.position;
            mask.SetActive(true);
        }
        else
        {
            mask.SetActive(false);
        }
    }

    // 全局 UI 显示接口
    public void UseUI(string choice, params string[] parameters)
    {
        switch (choice)
        {
            case "Item":
                UseItemInfoUI(parameters[0].Trim());
                break;
            case "Talk":
                Debug.Log("Talk");
                UseTalkBoxUI(parameters[0].Trim());
                break;
            case "PackItem":
                UsePackItemInfoUI(parameters[0].Trim());
                break;
            case "Bag":
                UseBagUI();
                break;
            case "Though":
                UseThoughUI(parameters[0].Trim(), float.Parse(parameters[1]));
                break;
            case "Comfirm":
                UseComfirmBoxUI(parameters[0], parameters[1], parameters.Skip(2).ToArray());
                break;
            case "ItemToCode":
                UseItemToCodeInfoUI(parameters[0].Trim());
                break;
            default:
                throw new Exception("Invalid UseUI Choice: " + choice);
        }
    }

    // 下列是各个 UI 的使用接口

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
        Debug.Log(talkerName);
        Debug.Log(talkBox.sprite);
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

    public void UseItemToCodeInfoUI(string itemName)
    {
        itemToCodeInfoUI.SetActive(true);
        itemToCodeInfo.itemSprite = global.LoadItemSpite(itemName);
        itemToCodeInfo.codeSprite = global.LoadItemSpite(itemName + "Code");
        itemToCodeInfo.textAsset = global.LoadItemTextAsset(itemName);
        itemToCodeInfo.Show();
    }
}