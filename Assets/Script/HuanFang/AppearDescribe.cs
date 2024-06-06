using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearDescribe : MonoBehaviour
{
    public GameObject talkBox;
    public GameObject describe;
    private bool talkActive = false;
    void Start()
    {

    }

    void Update()
    {
        if (!talkActive && talkBox.activeSelf)
        {
            talkActive = true;
        }

        if (talkActive && !talkBox.activeSelf)
        {
            describe.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
