using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    [Header("所有算珠")]
    public Bead Five1;
    public Bead Five2;
    public Bead One1;
    public Bead One2;
    public Bead One3;
    public Bead One4;
    public Bead One5;

    public int sum;

    void Update()
    {
        // 计算总和
        sum = (Five1.added ? 5 : 0) + (Five2.added ? 5 : 0) + (One1.added ? 1 : 0) + (One2.added ? 1 : 0) + (One3.added ? 1 : 0) + (One4.added ? 1 : 0) + (One5.added ? 1 : 0);
    }
}
