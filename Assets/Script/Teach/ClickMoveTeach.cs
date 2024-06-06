using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 点击移动教程
public class ClickMoveTeach : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
}
