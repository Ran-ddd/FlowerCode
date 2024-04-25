using UnityEngine;

public class Item : MonoBehaviour
{
    private SelectTrigger selectTrigger;
    private Global global = Global.Instance;

    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();

        if (IsCollected())
        {
            gameObject.SetActive(false);
        }
        else
        {
            selectTrigger.Select += Collect;
        }
    }

    void Collect()
    {
        global.UseUI("Item", name);
        CollectItem();
        selectTrigger.Select -= Collect;
    }

    void CollectItem()
    {
        gameObject.SetActive(false);
        global.collectItems.Add(name);
    }


    bool IsCollected()
    {
        return global.collectItems.Contains(name);
    }
}
