using UnityEngine;

public class AppearProgress : MonoBehaviour
{
    // 全局单例
    private Global global = Global.Instance;

    [Header("消失进度")]
    public string disappearProgress = "";

    [Header("出现进度")]
    public string appearProgress = "";

    [Header("可多次使用")]
    public bool reusable = false;

    [Header("属于管理对象")]
    public bool isAppearManager = false;

    [Header("管理对象")]
    public GameObject obj;


    void Start()
    {
        // 初始化检查
        if (appearProgress == global.progress)
        {
            gameObject.SetActive(true);
        }

        if (disappearProgress == global.progress)
        {
            gameObject.SetActive(false);
        }

        // 跟踪检查
        if (disappearProgress != "")
        {
            DisappearManage();
        }

        if (appearProgress != "")
        {
            AppearManage();
        }
    }

    void DisappearManage()
    {
        if (isAppearManager)
        {
            global.NextProgress += WaitForDisappear;
        }
        else
        {
            CreateManager();
            disappearProgress = "";
        }
    }

    void AppearManage()
    {
        if (isAppearManager)
        {
            global.NextProgress += WaitForAppear;
        }
        else
        {
            CreateManager();
            appearProgress = "";
            gameObject.SetActive(false);
        }
    }

    void CreateManager()
    {
        // 创建管理对象
        GameObject manager = new GameObject("AP" + name, typeof(AppearProgress));
        AppearProgress managerAp = manager.GetComponent<AppearProgress>();
        managerAp.disappearProgress = disappearProgress;
        managerAp.appearProgress = appearProgress;
        managerAp.isAppearManager = true;
        managerAp.obj = gameObject;

        // 放置管理对象
        manager.transform.SetParent(transform.parent);
        transform.SetParent(manager.transform);
    }

    void OnDisable()
    {
        if (isAppearManager)
        {
            global.NextProgress -= WaitForAppear;
            global.NextProgress -= WaitForDisappear;
        }
    }

    void WaitForAppear()
    {
        if (appearProgress == global.progress)
        {
            obj.SetActive(true);
        }
    }

    void WaitForDisappear()
    {

        if (disappearProgress == global.progress)
        {
            obj.SetActive(false);
        }
    }
}