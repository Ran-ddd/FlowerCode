using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
