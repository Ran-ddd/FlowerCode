using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlankItem : MonoBehaviour
{
    [Header("棋盘")]
    public PuzzleBoard puzzleBoard;

    [Header("块名称")]
    public string codeName;

    [Header("块内文字与图像")]
    public TMP_Text textUI;
    public Sprite bg;
    private Image image;
    private Color originColor;

    void Start()
    {
        image = GetComponent<Image>();
        originColor = image.color;
    }

    void Update()
    {
        // 拖放检测
        if (Input.GetMouseButtonUp(0) && RectTransformUtility.RectangleContainsScreenPoint((RectTransform)transform, Input.mousePosition))
        {
            // 拖放 or 置空
            if (puzzleBoard.isDragTo)
            {
                Set();
            }
            else
            {
                Reset();
            }
        }
    }

    // 成功拖放：显示图片与文字，接触拖放状态
    void Set()
    {
        textUI.text = puzzleBoard.codeText;
        image.color = new(255, 255, 255, 1f);
        image.sprite = bg;
        codeName = puzzleBoard.codeName;
        puzzleBoard.isDragTo = false;
    }

    // 格子置空：消除图片、文字、信息
    public void Reset()
    {
        textUI.text = "";
        image.color = originColor;
        image.sprite = null;
        codeName = "";
    }
}
