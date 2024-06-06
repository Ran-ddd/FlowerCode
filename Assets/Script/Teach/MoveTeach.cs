using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 移动教程
public class MoveTeach : MonoBehaviour
{
    private SelectTrigger selectTrigger;
    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();
        selectTrigger.Touch += Touch;
    }
    void Touch()
    {
        gameObject.SetActive(false);
        selectTrigger.Touch -= Touch;
    }
}