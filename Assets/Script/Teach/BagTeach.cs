using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// 打开背包教程
public class BagTeach : MonoBehaviour
{
    public Button bag;
    public GameObject indicatorUI;

    void Start()
    {
        bag.onClick.AddListener(ClickBag);
    }

    void OnEnable()
    {
        indicatorUI.SetActive(true);
    }

    void OnDisable()
    {
        indicatorUI.SetActive(false);
    }

    void ClickBag()
    {
        bag.onClick.RemoveListener(ClickBag);
        gameObject.SetActive(false);
    }
}