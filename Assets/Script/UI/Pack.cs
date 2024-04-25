using System.Linq;
using UnityEngine;

public class Pack : MonoBehaviour
{
    private Global global = Global.Instance;

    void OnEnable()
    {
        string[] itemNames = global.collectItems.ToArray();
        int n = itemNames.Length;

        for (int i = 0; i < n; i++)
        {
            GameObject item = GetItemWithOrder(i);
            item.SetActive(true);
            PackItem packItem = item.GetComponent<PackItem>();
            packItem.itemName = itemNames[i];
            packItem.RenewSprite();
        }
    }

    GameObject GetItemWithOrder(int order)
    {
        return transform.Find($"PackItem {order / 5 + 1}{order % 5 + 1}").gameObject;
    }
}
