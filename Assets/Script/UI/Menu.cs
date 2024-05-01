using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 提供给菜品按钮
public class Menu : MonoBehaviour
{
    private Global global = Global.Instance;

    // 可以选择菜单的菜品
    public void CanSelect()
    {
        global.UseUI("Talk", "Server");
        gameObject.SetActive(false);
    }

    // 不能选择的菜品
    public void CanNotSelect()
    {
        global.UseUI("Though", "没钱啊，吃点便宜的！！！", "1");
    }
}
