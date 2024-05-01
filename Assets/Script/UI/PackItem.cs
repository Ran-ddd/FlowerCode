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

    // 图片
    private Sprite originSprite;
    private Sprite transfromSprite;

    // 拖拽管理
    private bool isDrag = false;
    private bool isleavePack = false;

    // 放大倍数
    private float scalePower = 4f;

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
        RenewSprite();
        initPos = transform.position;
    }

    // 刷新图像
    public void RenewSprite()
    {
        image = GetComponent<Image>();
        image.sprite = originSprite = global.LoadItemSpite(itemName);
        transfromSprite = global.LoadItemSpite(itemName + "Transform");
    }

    void Update()
    {
        // 拖拽跟随 + 拖拽到一定距离发生事件
        if (isDrag)
        {
            Debug.Log(itemName + " is Drag");
            transform.position = Input.mousePosition;
            if (isleavePack != Vector3.Distance(transform.position, initPos) > leaveDistance)
            {
                isleavePack = !isleavePack;
                ItemIfLeavePack();
            }
        }
    }

    // 设置背包透明度
    void ItemIfLeavePack()
    {
        if (isleavePack)
        {
            LeavePackEffect();
        }
        else
        {
            ReturnPackEffect();
        }
    }

    // 离开背包
    void LeavePackEffect()
    {
        pack.GetComponent<Image>().color = new Color(255, 255, 255, 0.5f);
        transform.localScale *= scalePower;

        bool isCode = int.TryParse(itemName, out int result);
        if (isCode && transfromSprite != null)
        {
            image.sprite = transfromSprite;
        }
    }

    // 返回背包
    void ReturnPackEffect()
    {
        pack.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        transform.localScale /= scalePower;

        bool isCode = int.TryParse(itemName, out int result);
        if (isCode)
        {
            image.sprite = originSprite;
        }
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
            Return();
        }
    }

    // 回收物品，没有被消耗
    public void Return()
    {
        isDrag = false;
        transform.SetParent(pack.transform);
        transform.position = initPos;
        if (isleavePack)
        {
            ReturnPackEffect();
            isleavePack = false;
        }
    }

    // 回收，并且关闭背包
    public void ReturnAndCloseBag()
    {
        Return();
        global.itemBeDrag = null;
        gameObject.SetActive(false);
        global.UseUI("Bag", null);
        global.UseUI("PackItem", "Default");
    }
}
