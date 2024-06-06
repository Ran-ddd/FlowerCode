using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 测试脚本，有时用用
public class Test : MonoBehaviour
{
    void Start()
    {
        GetComponent<SelectTrigger>().Click += Click;
    }

    void Update()
    {

    }

    void Click()
    {
        Debug.Log("Click");
    }
}
