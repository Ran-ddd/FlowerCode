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

    // 选择门，切换场景
    void Select()
    {
        SceneManager.LoadScene(targetScene);
    }
}
