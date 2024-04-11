using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    GameObject child;
    float showCold = 0.3f;
    float coldTimer = 0f;

    void Start()
    {
        child = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.localPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            coldTimer = 0f;
            child.SetActive(true);
        }
        if (coldTimer < showCold)
        {
            coldTimer += Time.deltaTime;
        }
        else
        {
            child.SetActive(false);
        }
    }
}
