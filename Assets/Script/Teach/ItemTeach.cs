using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 物品拾取教程
public class ItemTeach : MonoBehaviour
{
    public SelectTrigger itemSelectTrigger;
    void Start()
    {
        itemSelectTrigger.Select += Select;
    }

    void Select()
    {
        gameObject.SetActive(false);
        itemSelectTrigger.Select -= Select;
    }
}