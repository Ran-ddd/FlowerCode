using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeach : MonoBehaviour
{

    public SelectTrigger doorSelectTrigger;
    void Start()
    {
        doorSelectTrigger.Select += Select;
    }

    void Select()
    {
        gameObject.SetActive(false);
        doorSelectTrigger.Select -= Select;
    }
}