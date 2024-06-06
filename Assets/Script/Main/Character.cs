using UnityEngine;

public class Character : MonoBehaviour
{
    private SelectTrigger selectTrigger;
    public string itemNeed = "";
    public string codeGive = "";
    private Global global = Global.Instance;

    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();
        selectTrigger.Select += Talk;
        selectTrigger.DragTo += DragTo;
    }

    void Talk()
    {
        if (global.collectedItems.Contains(codeGive))
        {
            global.UseUI("Talk", name + "Code");
        }
        else
        {
            global.UseUI("Talk", name);
        }
    }

    void DragTo()
    {
        PackItem packItem = global.itemBeDrag.GetComponent<PackItem>();

        // 调试信息
        Debug.Log("Drag To");
        Debug.Log(global.itemBeDrag);
        Debug.Log(itemNeed == packItem.itemName);
        Debug.Log(global.itemProgress.ContainsKey(itemNeed));
        if (global.itemProgress.ContainsKey(itemNeed))
        {
            Debug.Log(global.progress == global.itemProgress[itemNeed]);
        }

        // 检查是否满足拖放条件
        if (itemNeed == packItem.itemName && global.itemProgress.ContainsKey(itemNeed) && global.progress == global.itemProgress[itemNeed])
        {
            // 满足条件：消耗物品，推进进度，触发对话
            global.collectedItems.Remove(itemNeed);
            global.comsumedItems.Add(itemNeed);
            global.NextProgress();
            packItem.ReturnAndCloseBag();
            Talk();
        }
        else
        {
            // 不满足条件：回收物品
            packItem.Return();
        }
    }
}
