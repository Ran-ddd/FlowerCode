using UnityEngine;

public class Item : MonoBehaviour
{
    private SelectTrigger selectTrigger;
    private Global global = Global.Instance;

    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();

        if (IsCollectedOrConSumed())
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
        global.collectedItems.Add(name);
    }


    bool IsCollectedOrConSumed()
    {
        return global.collectedItems.Contains(name) || global.comsumedItems.Contains(name);
    }
}
