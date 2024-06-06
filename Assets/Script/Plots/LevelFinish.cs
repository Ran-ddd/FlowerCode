using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public int gameLevel;
    public string levelName;
    public string returnCode;
    public string word = "成功通关，获取苏州码一枚！";
    private Global global = Global.Instance;
    void Update()
    {
        // 如果游戏关卡完成，返还苏州码
        if (global.gameLevels[gameLevel] && !global.collectedItems.Contains(returnCode))
        {
            Debug.Log("finish");
            global.UseUI("Though", word, "3");
            global.UseUI("Item", levelName);
            global.collectedItems.Add(returnCode);
        }
    }
}
