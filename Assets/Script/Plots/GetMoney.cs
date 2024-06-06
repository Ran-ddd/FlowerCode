using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 获取金币：比较特殊，没用item.cs，因为需要将物品分成两份加入背包，比较特殊
public class GetMoney : MonoBehaviour
{
    private SelectTrigger selectTrigger;
    private Global global = Global.Instance;
    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();
        selectTrigger.Select += GetCoin;
    }
    void GetCoin()
    {
        global.collectedItems.Add("Coin");
    }
}
