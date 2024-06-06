using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 返回主菜单
public class ReturnMenu : MonoBehaviour
{
    public int mainScene = 0;
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(mainScene);
    }
}
