using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CommitBoard : MonoBehaviour
{
    public TMP_Text codeUI;
    public TMP_Text sumUI;
    public ResetBoard resetUI;
    public GameObject winUI;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;

    private int[] leftNums;
    private int[] rightNums;
    private int[] results;
    private GameObject[] fires;
    private int index;

    void Start()
    {
        // 答案: 137, 13940, 5682064
        leftNums = new int[] { 45, 8293, 1589251 };
        rightNums = new int[] { 92, 5647, 4092813 };
        results = leftNums.Zip(rightNums, (x, y) => x + y).ToArray();
        fires = new GameObject[] { fire1, fire2, fire3 };
        index = 0;
        ShowQuestion();
    }

    void Update()
    {

    }

    void ShowQuestion()
    {
        codeUI.text = NumToCode(leftNums[index]) + "  加  " + NumToCode(rightNums[index]);
    }

    public void Commit()
    {
        int result = CodeToNum(sumUI.text);
        if (result == results[index])
        {
            if (index < results.Length - 1)
            {
                fires[index].SetActive(true);
                index++;
                ShowQuestion();
                resetUI.BoardReset();
            }
            else
            {
                fires[index].SetActive(true);
                winUI.SetActive(true);
            }
        }
    }

    int CodeToNum(string code)
    {
        Dictionary<char, int> reverseMap = "〇〡〢〣〤〥〦〧〨〩〸〹〺".Select((c, i) => new KeyValuePair<char, int>(c, i)).ToDictionary(pair => pair.Key, pair => pair.Value);
        return code.Aggregate(0, (current, c) => current * 10 + reverseMap[c]);
    }

    string NumToCode(int num)
    {
        string codeMap = "〇〡〢〣〤〥〦〧〨〩〸〹〺";
        return new string(num.ToString().Select(c => codeMap[c - '0']).ToArray());
    }
}
