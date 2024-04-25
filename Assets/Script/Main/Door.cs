using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int targetScene;
    private SelectTrigger selectTrigger;
    void Start()
    {
        selectTrigger = GetComponent<SelectTrigger>();
        selectTrigger.Select += Select;
    }

    private void OnDisable()
    {
        selectTrigger.Select -= Select;
    }

    void Select()
    {
        SceneManager.LoadScene(targetScene);
    }
}
