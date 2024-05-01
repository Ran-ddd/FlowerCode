using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    [Header("背包")]
    public Image pack;
    private bool packActive = false;

    // 打开或关闭背包
    public void TooglePack()
    {
        packActive = !packActive;
        pack.gameObject.SetActive(packActive);
    }
}
