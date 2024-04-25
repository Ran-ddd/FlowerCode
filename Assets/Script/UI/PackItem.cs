using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PackItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    // 全局单例
    private Global global = Global.Instance;

    // 图像组件
    private Image image;

    // 拖拽管理
    private bool isDrag = false;

    [Header("父对象")]
    public GameObject canvas;
    public GameObject pack;

    [Header("背包透明")]
    public float leaveDistance = 50f;
    private Vector3 initPos;

    [Header("物品名称")]
    public string itemName;


    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = global.LoadItemSpite(itemName);
        initPos = transform.position;
    }

    public void RenewSprite()
    {
        GetComponent<Image>().sprite = global.LoadItemSpite(itemName);
    }

    void Update()
    {
        if (isDrag)
        {
            transform.position = Input.mousePosition;
            SetPackAlpha(Vector3.Distance(transform.position, initPos) > leaveDistance);
        }
    }

    void SetPackAlpha(bool leavePack)
    {
        pack.GetComponent<Image>().color = new Color(255, 255, 255, leavePack ? 0.5f : 1f);
    }

    // 悬浮时显示信息
    public void OnPointerEnter(PointerEventData eventData)
    {
        global.UseUI("PackItem", itemName);
    }

    // 离开时不显示
    public void OnPointerExit(PointerEventData eventData)
    {
        global.UseUI("PackItem", "Default");
    }

    // 按下时可以拖拽
    public void OnPointerDown(PointerEventData eventData)
    {
        IntoDrag();
    }

    void IntoDrag()
    {
        isDrag = true;
        global.itemBeDrag = gameObject;
        transform.SetParent(canvas.transform, true);
    }


    // 松开时，可能被消耗，可能被回收
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!global.willDragTo)
        {
            Recycle();
        }
    }

    public void Recycle()
    {
        isDrag = false;
        global.itemBeDrag = null;
        transform.SetParent(pack.transform);
        transform.position = initPos;
        pack.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
    }

    public void Consume()
    {
        Recycle();
        gameObject.SetActive(false);
        global.UseUI("Bag", null);
        global.UseUI("PackItem", "Default");
    }
}
