using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PuzzleBoard : MonoBehaviour
{
    [Header("空格")]
    public List<BlankItem> blankNumberItems;
    public List<BlankItem> blankUnitsItems;

    [Header("谜题")]
    public TMP_Text questionTextUI;
    public List<string> questions;
    public List<string> answers;
    private int index = -1;

    [Header("进度")]
    public List<GameObject> resultsUI;

    [Header("胜利")]
    public GameObject winUI;

    [Header("拖拽信息")]
    public string codeText;
    public string codeName;
    public bool isDragTo;

    void Start()
    {
        NextQuestion();
    }

    // 提交棋盘
    public void CommitBoard()
    {
        // 结果判断
        if (CalcResult() == answers[index])
        {
            NextQuestion();
            ResetBoard();
        }
    }

    // 计算结果
    string CalcResult()
    {
        return blankNumberItems.Aggregate("", (current, item) => current + item.codeName) + " " + blankUnitsItems.Aggregate("", (current, item) => current + item.codeName);
    }

    // 下一个问题
    void NextQuestion()
    {
        if (index >= 0) resultsUI[index].SetActive(true);

        // 边界检测：胜利/下一题
        if (++index < questions.Count)
        {
            questionTextUI.text = questions[index];
        }
        else
        {
            Win();
        }
    }

    // 游戏胜利
    void Win()
    {
        winUI.SetActive(true);
    }

    // 重置棋盘：清除数据
    public void ResetBoard()
    {
        codeText = "";
        codeName = "";
        isDragTo = false;
        foreach (var item in blankNumberItems)
        {
            item.Reset();
        }
        foreach (var item in blankUnitsItems)
        {
            item.Reset();
        }
    }
}
