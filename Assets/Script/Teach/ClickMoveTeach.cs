using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
