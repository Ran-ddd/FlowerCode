using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HuaRongBorad : MonoBehaviour
{
    public static HuaRongBorad Inst;
    public GameObject Cellitem;
    public List<Sprite> mapsps;
    public GameObject winUI;
    public int row = 3;
    public int col = 3;
    private Dictionary<int, Cellitem> dataDict = new Dictionary<int, Cellitem>();
    private List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 0 };

    void shuffle()
    {
        int zeroIndex = 8;
        for (int i = 0; i < 100; i++)
        {
            List<int> positions = new List<int>();

            if (zeroIndex % 3 != 0) positions.Add(zeroIndex - 1);
            if (zeroIndex % 3 != 2) positions.Add(zeroIndex + 1);
            if (zeroIndex + 3 < numbers.Count) positions.Add(zeroIndex + 3);
            if (zeroIndex - 3 >= 0) positions.Add(zeroIndex - 3);

            int position = positions[Random.Range(0, positions.Count)];
            (numbers[zeroIndex], numbers[position]) = (numbers[position], numbers[zeroIndex]);
            zeroIndex = position;
        }
    }

    Cellitem findCeilItem(int rIdx, int cIdx)
    {
        foreach (KeyValuePair<int, Cellitem> kv in dataDict)
        {
            if (kv.Value.rIdx == rIdx && kv.Value.cIdx == cIdx)
                return kv.Value;

        }
        return null;
    }



    Vector3 getCellitemPos(int i, int j)
    {
        Vector3 ve = default;
        ve.x = 1 * j;
        ve.y = -1 * i;
        return ve;
    }

    bool CheckCeilcorrect(int rIdx, int cIdx)
    {
        if (rIdx < 0 || rIdx >= row || cIdx < 0 || cIdx >= col)
        {
            return false;
        }
        return true;
    }

    bool findNullCeil(int rIdx, int cIdx)
    {
        if (CheckCeilcorrect(rIdx, cIdx) == false)
            return false;
        Cellitem ceil = findCeilItem(rIdx, cIdx);
        if (ceil != null)
        {
            return ceil.number == 0;
        }
        return false;

    }

    public void checkSwap(int rIdx, int cIdx, int clicknum)
    {
        (int, int) res = FOURfindNullCeil(rIdx, cIdx);
        if (res.Item1 != 999)
            Swap(clicknum, 0);
    }

    void Swap(int clicknum, int nullnum)
    {
        Cellitem clickItem = dataDict[clicknum];
        Cellitem nullItem = dataDict[nullnum];
        Vector3 clickpos = clickItem.transform.position;
        clickItem.transform.position = nullItem.transform.position;
        nullItem.transform.position = clickpos;
        Swapdata(clickItem, nullItem);
    }

    void Swapdata(Cellitem clickItem, Cellitem nullItem)
    {
        var clickrIdx = clickItem.rIdx;
        var clickcIdx = clickItem.cIdx;
        clickItem.updateIdx(nullItem.rIdx, nullItem.cIdx);
        nullItem.updateIdx(clickrIdx, clickcIdx);
        isWin();
    }


    int totalceil;
    bool isWin()
    {
        bool res = false;
        int startnum = 1;
        totalceil = row * col;
        for (int i = 0; i < row; i++)
            for (int j = 0; j < col; j++)
            {
                var ceil = findCeilItem(i, j);
                if (startnum == totalceil)
                {
                    res = ceil.number == 0;
                    continue;
                }


                if (ceil.number != startnum)
                {
                    return res;
                }
                startnum++;
            }

        if (res)
        {
            winUI.SetActive(true);
        }
        return res;
    }

    public (int, int) FOURfindNullCeil(int rIdx, int cIdx)
    {
        List<(int, int)> dirs = new List<(int, int)>() {
        (rIdx + 1, cIdx),
            (rIdx - 1, cIdx),
            (rIdx,cIdx + 1),
            (rIdx,cIdx - 1)};
        for (int i = 0; i < dirs.Count; i++)
        {
            (int, int) Item = dirs[i];


            if (findNullCeil(Item.Item1, Item.Item2))
                return Item;

        }

        return (999, 999);
    }
    void InitMap()
    {
        shuffle();
        for (int i = 0; i < numbers.Count; i++)
        {
            Debug.Log(numbers[i]);
        }
        int numberIdx = 0;
        for (int i = 0; i < row; i++)
            for (int j = 0; j < col; j++)
            {
                Vector3 pos = getCellitemPos(i, j);
                var go = GameObject.Instantiate(Cellitem, pos + new Vector3(-1, 1, 0), Quaternion.identity, gameObject.transform);
                var cellItem = go.GetComponent<Cellitem>();
                int number = numbers[numberIdx];
                cellItem.Init(number, i, j);
                dataDict.Add(number, cellItem);
                numberIdx++;
            }
    }

    private void Awake()
    {
        Inst = this;
    }

    void Start()
    {
        InitMap();
    }

    void Update()
    {

    }
}
