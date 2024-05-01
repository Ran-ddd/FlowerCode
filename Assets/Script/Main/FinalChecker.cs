using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalChecker : MonoBehaviour
{
    // 全局单例
    private Global global = Global.Instance;

    void Start()
    {
        Invoke(nameof(Check), 8f);
    }

    public void Check()
    {
        int numCount = 0;
        foreach (string item in global.collectedItems)
        {
            if (int.TryParse(item, out int num))
            {
                numCount++;
            }
        }
        if (numCount >= 8)
        {
            global.UseUI("Though", "所有的苏州码都收集齐了！", "5");
            Invoke(nameof(GoToHuanFang), 5f);
        }
        else
        {
            Invoke(nameof(Check), 10f);
        }
    }

    void GoToHuanFang()
    {
        SceneManager.LoadScene(7);
    }
}