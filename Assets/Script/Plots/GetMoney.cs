using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        global.collectItems.Add("Coin");
    }
}
