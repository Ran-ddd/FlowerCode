using UnityEngine;

public class ServeDish : MonoBehaviour
{
    private SelectTrigger selectTrigger;
    private Global global = Global.Instance;

    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();
        selectTrigger.Select += GiveDish;
    }
    void GiveDish()
    {
        global.NextProgress();
        global.UseUI("Talk", "Waiter");
        gameObject.SetActive(false);
    }
}