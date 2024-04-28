using UnityEngine;

public class Character : MonoBehaviour
{
    private SelectTrigger selectTrigger;
    public string itemNeed = "";
    private Global global = Global.Instance;

    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();
        selectTrigger.Select += Talk;
        selectTrigger.DragTo += DragTo;
    }

    void Talk()
    {
        global.UseUI("Talk", name);
    }

    void DragTo()
    {
        PackItem packItem = global.itemBeDrag.GetComponent<PackItem>();

        Debug.Log("Drag To");
        Debug.Log(global.itemBeDrag);
        Debug.Log(itemNeed == packItem.itemName);
        Debug.Log(global.itemProgress.ContainsKey(itemNeed));
        if (global.itemProgress.ContainsKey(itemNeed))
        {
            Debug.Log(global.progress == global.itemProgress[itemNeed]);
        }



        if (itemNeed == packItem.itemName && global.itemProgress.ContainsKey(itemNeed) && global.progress == global.itemProgress[itemNeed])
        {
            global.collectedItems.Remove(itemNeed);
            global.comsumedItems.Add(itemNeed);
            global.NextProgress();
            packItem.Consume();
            Talk();
        }
        else
        {
            packItem.Recycle();
        }
    }
}
