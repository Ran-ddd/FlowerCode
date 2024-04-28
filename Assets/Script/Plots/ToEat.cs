using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToEat : MonoBehaviour
{
    private SelectTrigger selectTrigger;
    private Global global = Global.Instance;

    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();
        selectTrigger.Touch += WantToEat;
    }

    void WantToEat()
    {
        global.UseUI("Though", "有点饿了，快点去吃个饭", "2");
        gameObject.SetActive(false);
    }

}
