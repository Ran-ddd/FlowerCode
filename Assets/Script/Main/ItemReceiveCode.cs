using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 需要苏州码辅助的物品
public class ItemReceiveCode : MonoBehaviour
{
    // 全局单例
    private Global global = Global.Instance;

    // 触发器 
    private SelectTrigger selectTrigger;

    // 动画
    private Animator animator;

    // 是否接受
    public bool isReceive = false;

    [Header("需要的码")]
    public string itemNeed = "";

    void Start()
    {
        animator = GetComponent<Animator>();
        selectTrigger = GetComponent<SelectTrigger>();
        selectTrigger.DragTo = DragTo;
    }

    void DragTo()
    {
        PackItem packItem = global.itemBeDrag.GetComponent<PackItem>();

        // 调试信息
        Debug.Log(global.itemBeDrag + " Drag To " + name + ": " + (itemNeed == packItem.itemName));

        // 检查是否满足拖放条件
        if (itemNeed == packItem.itemName)
        {
            animator.SetTrigger("Receive");
            packItem.ReturnAndCloseBag();
            isReceive = true;
        }
        else
        {
            packItem.Return();
        }
    }
}