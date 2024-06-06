using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 音量管理器
public class Audio : MonoBehaviour
{
    public Slider Soundctl;
    private float originVolume;
    void Start()
    {
        originVolume = AudioListener.volume;
        Soundctl.value = originVolume;
    }

    void Update()
    {
        AudioListener.volume = Soundctl.value;
    }
}
