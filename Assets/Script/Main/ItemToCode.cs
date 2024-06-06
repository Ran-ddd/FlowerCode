using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 与Item.cs类似，但属于用于收集苏州码的物品
public class ItemToCode : MonoBehaviour
{
    [Header("苏州码")]
    public string code;
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

    void Collect()
    {
        global.UseUI("ItemToCode", name + "To");
        CollectItem();
        selectTrigger.Select -= Collect;
    }

    void CollectItem()
    {
        gameObject.SetActive(false);
        global.collectedItems.Add(code);
    }

    bool IsCollectedOrConSumed()
    {
        return global.collectedItems.Contains(code) || global.comsumedItems.Contains(code);
    }
}
