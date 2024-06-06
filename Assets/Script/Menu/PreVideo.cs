using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreVideo : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject audio;
    public float videoSeconds = 0f;

    void Start()
    {
        Invoke(nameof(IntoMenu), videoSeconds);
    }

    void IntoMenu()
    {
        audio.SetActive(true);
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}