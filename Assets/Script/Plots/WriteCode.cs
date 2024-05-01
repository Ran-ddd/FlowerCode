using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteCode : MonoBehaviour
{
    public GameObject teacher;
    private SelectTrigger selectTrigger;
    private Global global = Global.Instance;
    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();
        selectTrigger.DragTo += DragTo;
    }

    public void DragTo()
    {
        PackItem packItem = global.itemBeDrag.GetComponent<PackItem>();

        if (packItem.itemName.Trim() == "9")
        {
            packItem.ReturnAndCloseBag();
            teacher.name += "Bill";
            global.UseUI("Talk", teacher.name);
            selectTrigger.Select -= DragTo;
            selectTrigger.Select += DragToTmp;
        }
        else
        {
            packItem.Return();
        }
    }

    void DragToTmp()
    {

    }
}
