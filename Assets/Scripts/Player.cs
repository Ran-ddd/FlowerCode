using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Vector2 position;
    bool isMoving = false;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        position = transform.localPosition;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            // 获取点击位置
            position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 direction = (position - rigidbody2d.position).normalized;

            rigidbody2d.MovePosition(rigidbody2d.position + direction * speed * Time.deltaTime);

            if (Vector2.Distance(rigidbody2d.position, position) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}

