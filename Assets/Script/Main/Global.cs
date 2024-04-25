using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Global
{
    // 单例管理
    private static volatile Global _instance;
    private static object _lock = new object();

    public static Global Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Global();
                }
            }
            return _instance;
        }
    }

    // 初始化
    private Global()
    {
        NextProgress = NextProgressMethod;
        NextProgress();
    }

    // 角色位置管理
    public Dictionary<int, Vector3> lastPositionInScenes = new();

    // UI 管理
    public UseUIDelegate UseUI;
    public TalkFinishDelegate TalkFinish;

    // 背包管理
    public HashSet<string> collectItems = new() { "Letter" };
    public GameObject itemBeDrag;
    public bool willDragTo = false;

    // 物品拖放被进度限制
    public Dictionary<string, string> itemProgress = new Dictionary<string, string> {
        {"Wallet", "Teach3"},
        {"Letter", "Money2"},
        {"Coin", "Eat3"},
    };

    // 进度管理
    public string progress;
    private int progressIndex = -1;
    private List<string> progresses = new List<string> {
        "Teach1", // 角色还没找到钱包，NPC 在找钱包
        "Teach2", // 角色找到钱包了，询问 NPC 是不是他的
        "Teach3", //# NPC 乞求归还 
        "Teach4", // 角色归还 NPC 钱包
        "Money1", // 角色去取钱，客服要求给侨批
        "Money2", //# 角色给出侨批
        "Money3", // 客服给钱了
        "Money4", // 钱出现了
        "Eat1", // 前台问角色吃什么，并弹出菜单
        "Eat2", // 角色说要吃面
        "Eat3", //# 前台让付钱，角色给钱
        "Eat4", // 前台让角色去桌上等
        "Eat5", // 上菜，店小二对话
        "Eat6", // 可以吃了
        "Eat7", // 吃完了
        "Default", // 游戏结束，自由探索
    };

    public NextProgressDelegate NextProgress;


    void NextProgressMethod()
    {
        progressIndex = Math.Min(progressIndex + 1, progresses.Count - 1);
        progress = progresses[progressIndex];
        Debug.Log($"Into Process: {progress}");
    }

    // TODO
    // // 事件触发 
    // private Dictionary<string, List<string>> events = new Dictionary<string, List<string>> {
    //     {"", new List<string> { "NPC" }}
    // };

    // public void EventTrigger(string source, string name)
    // {

    // }


    // <------------->

    // 资源管理
    public Sprite LoadItemSpite(string name)
    {
        Sprite sprite = Resources.Load<Sprite>("Sprite/Item/" + name);
        if (sprite == null)
        {
            throw new Exception("No such item sprite: " + name);
        }
        return sprite;
    }

    public Sprite LoadCharacterSpite(string name)
    {
        Sprite sprite = Resources.Load<Sprite>("Sprite/Character/" + name);
        if (sprite == null)
        {
            throw new Exception("No such character sprite: " + name);
        }
        return sprite;
    }

    public Sprite LoadCharacterHeadSpite(string name)
    {
        Sprite sprite = Resources.Load<Sprite>("Sprite/Character/" + name + "Head");
        if (sprite == null)
        {
            throw new Exception("No such character head sprite: " + name);
        }
        return sprite;
    }

    public TextAsset LoadItemTextAsset(string name)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Text/Item/" + name);
        if (textAsset == null)
        {
            throw new Exception("No such item text asset: " + name);
        }
        return textAsset;

    }

    public TextAsset LoadCharacterTextAsset(string name)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Text/Character/" + progress + "-" + name);
        TextAsset defaultTextAsset = Resources.Load<TextAsset>("Text/Character/" + "Default-" + name);
        if (textAsset == null)
        {
            if (defaultTextAsset == null)
            {
                throw new Exception("No such character text asset: " + progress + "-" + name + " or " + "Default-" + name);
            }
            return defaultTextAsset;
        }
        return textAsset;
    }

    // 通用函数
    public bool IsClickNotOnUI()
    {
        return Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();
    }
}




public delegate void TouchDelegate();
public delegate void SelectDelegate();
public delegate void DragToDelegate();

public delegate void NextProgressDelegate();
public delegate void UseUIDelegate(string choice, params string[] parameters);
public delegate void TalkFinishDelegate(string name);