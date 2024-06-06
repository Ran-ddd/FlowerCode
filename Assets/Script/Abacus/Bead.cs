using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bead : MonoBehaviour
{
    [Header("棋子类型")]
    public bool one = true;

    [Header("移动距离")]
    public float distance = 0.4f;

    [Header("是否计入")]
    public bool added = false;

    [Header("相邻棋子")]
    public Bead pre;
    public Bead next;

    void Start()
    {
        distance *= one ? 1 : -1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 碰撞检测
        if (other.gameObject.CompareTag("Cursor"))
        {
            other.gameObject.GetComponent<CircleCollider2D>().enabled = false;

            // 检测到点击，改变位置
            Change();
        }
    }

    // 算珠移动
    public void Change()
    {
        // 当前算珠改变位置
        added = !added;
        transform.localPosition += new Vector3(0, distance * (added ? 1 : -1), 0);

        // 递归改变相邻算珠位置
        if (pre != null)
        {
            pre.ChangeByClose(false, added);
        }
        if (next != null)
        {
            next.ChangeByClose(true, added);
        }
    }

    // 递归改变算珠位置，实现一次拨动多个
    public void ChangeByClose(bool isCallerPre, bool isCallerAdd)
    {
        // 判断向前拨动还是向后拨动
        if (isCallerPre && !isCallerAdd && added)
        {
            added = false;
            transform.localPosition += new Vector3(0, distance * (added ? 1 : -1), 0);
            if (next != null)
            {
                next.ChangeByClose(true, added);
            }
        }
        else if (!isCallerPre && isCallerAdd && !added)
        {
            added = true;
            transform.localPosition += new Vector3(0, distance * (added ? 1 : -1), 0);
            if (pre != null)
            {
                pre.ChangeByClose(false, added);
            }
        }
    }
}
