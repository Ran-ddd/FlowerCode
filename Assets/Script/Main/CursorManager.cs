using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


// 与光标点击移动相关的管理器: 用来触发的光标、用于人物自动寻路的光标、点击效果
public class CursorManager : MonoBehaviour
{
    // 全局单例
    private Global global = Global.Instance;

    [Header("触发光标")]
    public Transform triggerCursor;

    [Header("角色寻路终点")]
    public Transform playerTarget;
    private SpriteRenderer playerTargetSR;

    [Header("点击效果时间")]
    public float clickEffectTime = 0.1f;

    void Start()
    {
        playerTargetSR = playerTarget.GetComponent<SpriteRenderer>();

        // 恢复上一次离开场景的位置
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (global.lastPositionInScenes.ContainsKey(sceneIndex))
        {
            transform.position = global.lastPositionInScenes[sceneIndex] + new Vector3(0, -1f, 0);
        }
    }

    void Update()
    {
        // 触发光标 移动到鼠标位置
        PositionFollowCursor(triggerCursor);

        if (global.IsClickNotOnUI())
        {
            // 寻路光标 移动到鼠标点击位置
            PositionFollowCursor(playerTarget);
            // 出现点击效果(限时)
            CancelInvoke(nameof(ClearClickEffect));
            ShowClickEffect();
            Invoke(nameof(ClearClickEffect), clickEffectTime);
        }
    }

    void ShowClickEffect()
    {
        playerTargetSR.enabled = true;
    }

    void ClearClickEffect()
    {
        playerTargetSR.enabled = false;
    }

    void PositionFollowCursor(Transform trans)
    {
        trans.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
