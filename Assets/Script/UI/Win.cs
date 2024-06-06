using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 胜利界面
public class Win : MonoBehaviour
{
    public int returnScene = 1;
    private Global global = Global.Instance;
    void Update()
    {
        // 点击返回主世界场景
        if (Input.GetMouseButtonUp(0))
        {
            global.gameLevels[SceneManager.GetActiveScene().buildIndex] = true;
            SceneManager.LoadScene(returnScene);
        }
    }
}
