using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Animator animator;
    private float dirX = 1;
    private float dirY = 1;
    private Vector3 originScale;
    private Global global = Global.Instance;
    public float offset = 0.1f;


    [Header("角色寻路终点")]
    public Transform playerTarget;

    void Start()
    {
        animator = GetComponent<Animator>();
        originScale = transform.localScale;
        // 恢复位置
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (global.lastPositionInScenes.ContainsKey(sceneIndex))
        {
            transform.position = global.lastPositionInScenes[sceneIndex];
        }
    }

    void OnDisable()
    {
        global.lastPositionInScenes[SceneManager.GetActiveScene().buildIndex] = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Update()
    {
        // 向量：由玩家到目标
        Vector3 displacement = playerTarget.position - transform.position;
        Debug.Log(displacement);

        if (Math.Abs(displacement.x) > offset)
        {
            dirX = Math.Sign(displacement.x);
        }
        if (Math.Abs(displacement.y) > offset)
        {
            Debug.Log("dir: " + Math.Sign(displacement.y - offset));
            dirY = Math.Sign(displacement.y + offset);
        }

        transform.localScale = new Vector3(dirX * originScale.x, originScale.y, originScale.y);
        animator.SetBool("move", displacement != Vector3.zero);
        animator.SetBool("back", dirY > 0 && Math.Abs(displacement.y) / Math.Abs(displacement.x) > 1f);
        animator.SetBool("lean", dirY > 0 && Math.Abs(displacement.y) / Math.Abs(displacement.x) <= 1f);
        animator.SetBool("idleback", dirY > 0);
    }
}
