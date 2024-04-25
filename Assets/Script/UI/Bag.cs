using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    public Image pack;
    private bool packActive = false;

    public void TooglePack()
    {
        packActive = !packActive;
        pack.gameObject.SetActive(packActive);
    }
}
