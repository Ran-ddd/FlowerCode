using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbacusCursor : MonoBehaviour
{
    private CircleCollider2D circleCollider2D;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        // 提供碰撞体，碰撞算珠
        if (Input.GetMouseButtonDown(0))
        {
            circleCollider2D.enabled = true;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}