using UnityEngine;

public class CameraSizer : MonoBehaviour
{
    // TODO
    void Start()
    {
        GameObject background = GameObject.FindGameObjectWithTag("Environment");
        SpriteRenderer backgroundRenderer = background.GetComponent<SpriteRenderer>();
        Vector2 backgroundSize = backgroundRenderer.bounds.size;
        Camera mainCamera = GetComponent<Camera>();

        // 设置相机的正交投影大小
        mainCamera.orthographicSize = Mathf.Max(backgroundSize.x / (2 * mainCamera.aspect), backgroundSize.y / 2);
    }
}
