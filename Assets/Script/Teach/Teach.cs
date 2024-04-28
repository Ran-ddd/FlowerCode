using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teach : MonoBehaviour
{
    public List<string> teachWords = new();
    public int index = -1;
    public GameObject child;
    private Global global = Global.Instance;

    void Start()
    {
        if (global.teachEnd)
        {
            gameObject.SetActive(false);
            return;
        }

        // 让所有子对象失效
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // 当前没有教学对象
        if (child == null || !child.activeSelf)
        {
            NextTeach();
        }
    }

    void NextTeach()
    {
        if (child != null) child.SetActive(false);
        child = transform.GetChild(++index).gameObject;
        if (index == transform.childCount - 1)
        {
            global.teachEnd = true;
        }
        child.SetActive(true);
        RenewWord();
    }

    void RenewWord()
    {
        global.UseUI("Though", teachWords[index], "0");
    }
}