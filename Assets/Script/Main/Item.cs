using UnityEngine;

public class Item : MonoBehaviour
{
    private SelectTrigger selectTrigger;
    private Global global = Global.Instance;

    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();

        if (IsCollectedOrConSumed())
        {
            gameObject.SetActive(false);
        }
        else
        {
            selectTrigger.Select += Collect;
        }
    }

    // 物品触发了收集
    void Collect()
    {
        global.UseUI("Item", name);
        CollectItem();
        selectTrigger.Select -= Collect;
    }

    // 物品收集
    void CollectItem()
    {
        gameObject.SetActive(false);
        global.collectedItems.Add(name);
    }

    // 物品是否已经被收集或消耗
    bool IsCollectedOrConSumed()
    {
        return global.collectedItems.Contains(name) || global.comsumedItems.Contains(name);
    }
}
