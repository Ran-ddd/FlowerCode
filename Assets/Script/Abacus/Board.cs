using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("所有算盘列")]
    public Column Column1;
    public Column Column2;
    public Column Column3;
    public Column Column4;
    public Column Column5;
    public Column Column6;
    public Column Column7;
    public TMP_Text sumUI;
    public int sum = 0;
    void Update()
    {
        // 计算总和并显示
        sum = Column1.sum + Column2.sum * 10 + Column3.sum * 100 + Column4.sum * 1000 + Column5.sum * 10000 + Column6.sum * 100000 + Column7.sum * 1000000;
        sumUI.text = NumToCode(sum);
    }


    // 将算珠的数字转换为对应的汉字

    string NumToCode(int num)
    {
        string codeMap = "〇〡〢〣〤〥〦〧〨〩〸〹〺";
        return new string(num.ToString().Select(c => codeMap[c - '0']).ToArray());
    }
}
