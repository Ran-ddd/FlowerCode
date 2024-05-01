using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 开始游戏
public class PlayGame : MonoBehaviour
{
    public int scene = 1;

    public void OnClick()
    {
        SceneManager.LoadScene(scene);
    }

}
