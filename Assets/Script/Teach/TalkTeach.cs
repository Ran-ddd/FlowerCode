using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTeach : MonoBehaviour
{
    public SelectTrigger characterSelectTrigger;
    void Start()
    {
        characterSelectTrigger.Select += Select;
    }

    void Select()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }
}