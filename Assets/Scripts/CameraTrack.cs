using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10);
    private Transform target;
    private Vector3 position;
    public float speed = 0.1f;
    public float minDistance = 1f;
    bool move = false;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > minDistance)
        {
            move = true;
        }

        if (move)
        {
            position = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
            if (distance < 0.1f)
            {
                move = false;
            }
        }
    }
}