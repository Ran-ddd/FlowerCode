using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 退出游戏
public class QuitGame : MonoBehaviour
{
    public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
