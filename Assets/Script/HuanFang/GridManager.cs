using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("华容道结束视频")]
    public GameObject gameOverVideo;

    [Header("大结尾视频")]
    public GameObject finalVideo;

    [Header("设置按钮")]
    public GameObject setting;

    [Header("游戏介绍按钮")]
    public GameObject gameIntro;

    [Header("游戏音效")]
    public GameObject audio;


    public static GridManager Instance;
    public List<Grid> grids;
    private void Awake()
    {
        Instance = this;
    }

    public void OnPutRigtht(Grid g)
    {
        grids.Remove(g);
        if (grids.Count == 0)
        {
            audio.SetActive(false);
            setting.SetActive(false);
            gameIntro.SetActive(false);

            gameOverVideo.SetActive(true);
            Invoke(nameof(VideoEnd), 41f);
        }
    }

    void VideoEnd()
    {
        gameOverVideo.SetActive(false);
        finalVideo.SetActive(true);
        Invoke(nameof(Final), 60f);
    }

    void Final()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
