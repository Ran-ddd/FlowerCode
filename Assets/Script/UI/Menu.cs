using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private Global global = Global.Instance;

    public void CanSelect()
    {
        global.UseUI("Talk", "Server");
        gameObject.SetActive(false);
    }

    public void CanNotSelect()
    {
        global.UseUI("Though", "没钱啊，吃点便宜的！！！", "1");
    }
}
