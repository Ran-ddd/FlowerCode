using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 背包拖放教程
public class PackTeach : MonoBehaviour
{
    public SelectTrigger characterSelectTrigger;
    void Start()
    {
        characterSelectTrigger.DragTo += DragTo;
    }

    void DragTo()
    {
        gameObject.SetActive(false);
    }
}