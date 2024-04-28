using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackTeach : MonoBehaviour
{
    public SelectTrigger characterSelectTrigger;
    void Start()
    {
        characterSelectTrigger.DragTo += DragTo;
    }

    void DragTo()
    {
        gameObject.SetActive(false);
    }
}