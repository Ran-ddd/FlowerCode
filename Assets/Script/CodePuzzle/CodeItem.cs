using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CodeItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("块内文字")]
    public TMP_Text textUI;

    [Header("棋盘")]
    public PuzzleBoard puzzleBoard;

    // 拖拽状态
    private bool isDrag;

    // 初始位置
    private Vector3 originPos;

    void Start()
    {
        originPos = transform.position;
    }

    void Update()
    {
        if (isDrag)
        {
            // 拖拽跟随
            transform.position = Input.mousePosition;
        }
    }

    // 拖拽开始
    public void OnPointerDown(PointerEventData eventData)
    {
        isDrag = puzzleBoard.isDragTo = true;
        puzzleBoard.codeText = textUI.text;
        puzzleBoard.codeName = name;
    }

    // 拖拽结束
    public void OnPointerUp(PointerEventData eventData)
    {
        isDrag = false;
        ResetPos();
    }

    // 复位
    void ResetPos()
    {
        transform.position = originPos;
    }
}
