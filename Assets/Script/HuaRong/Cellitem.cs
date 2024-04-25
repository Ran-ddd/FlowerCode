using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cellitem : MonoBehaviour
{
    public int rIdx { get; private set; }
    public int cIdx { get; private set; }

    [HideInInspector]
    public int number;
    private SpriteRenderer sp;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void Init(int number, int rLdx, int cIdx)
    {

        this.number = number;
        this.rIdx = rLdx;
        this.cIdx = cIdx;

        UpdateSP(this.number);
    }

    public void updateIdx(int rIdx, int cIdx)
    {
        this.rIdx = rIdx;
        this.cIdx = cIdx;
    }

    private void OnMouseDown()
    {
        if (number == 0) return;
        HuaRongBorad.Inst.checkSwap(rIdx, cIdx, number);
    }

    public void UpdateSP(int number)
    {

        if (number == 0)
        {
            sp.sprite = HuaRongBorad.Inst.mapsps[9];
        }
        else
        {
            int idx = number - 1;
            sp.sprite = HuaRongBorad.Inst.mapsps[idx];
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
