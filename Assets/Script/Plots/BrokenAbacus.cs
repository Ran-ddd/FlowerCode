using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenAbacus : MonoBehaviour
{
    public GameObject server;
    public GameObject fixedAbacus;
    private ItemReceiveCode itemReceiveCode;
    private Global global = Global.Instance;
    private string thing = "Fix Abacus";

    void Start()
    {
        itemReceiveCode = GetComponent<ItemReceiveCode>();

        if (global.finishedThings.Contains(thing))
        {
            fixedAbacus.SetActive(true);
            server.name += "Abacus";
        }
    }

    void Update()
    {
        if (itemReceiveCode.isReceive)
        {
            server.name += "Abacus";
            global.finishedThings.Add(thing);
            itemReceiveCode.isReceive = false;
            Global.Instance.UseUI("Though", "哇呜算盘修好了诶 ·-·", "2");
        }
    }
}
