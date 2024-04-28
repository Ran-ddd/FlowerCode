using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
