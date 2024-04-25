using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 4f, -10);
    private Transform target;
    private Vector3 cameraPosition;
    public float speed = 2f;

    private float maxCameraX;
    private float maxCameraY;
    private float minCameraX;
    private float minCameraY;
    private Camera mainCamera;
    private Vector2 bgHalfSize;
    private Vector2 bgCenter;


    void Start()
    {
        // 游戏玩家
        target = GameObject.FindGameObjectWithTag("Player").transform;

        // 计算相机的最大边界位置
        GameObject bg = GameObject.FindGameObjectWithTag("Environment");
        SpriteRenderer bgRenderer = bg.GetComponent<SpriteRenderer>();
        mainCamera = GetComponent<Camera>();

        // 获取背景图的 SpriteRenderer 组件和尺寸
        bgHalfSize = bgRenderer.bounds.extents;
        bgCenter = bgRenderer.bounds.center;
    }

    void Update()
    {
        // 相机的半长宽
        Vector2 cmHalfSize = new Vector2(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);

        // 计算相机的极限边界位置
        maxCameraX = bgCenter.x + bgHalfSize.x - cmHalfSize.x;
        maxCameraY = bgCenter.y + bgHalfSize.y - cmHalfSize.y;
        minCameraX = bgCenter.x - bgHalfSize.x + cmHalfSize.x;
        minCameraY = bgCenter.y - bgHalfSize.y + cmHalfSize.y;

        // 跟随游戏玩家
        cameraPosition = target.position + offset;

        // 限制相机位置在背景图的边界内
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, minCameraX, maxCameraX);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, minCameraY, maxCameraY);

        // 平滑移动相机
        transform.position = Vector3.Lerp(transform.position, cameraPosition, speed * Time.deltaTime);
    }
}