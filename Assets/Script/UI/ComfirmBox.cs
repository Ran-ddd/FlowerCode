using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComfirmBox : MonoBehaviour
{
    public string description;
    public string function;
    public string[] inputs;
    public TMP_Text text;
    private Global global = Global.Instance;

    public void Show()
    {
        text.text = description;
    }

    public void Yes()
    {
        switch (function)
        {
            case "LoadScene":
                SceneManager.LoadScene(int.Parse(inputs[0]));
                break;
            default:
                throw new Exception("No Such ComfirmBox Function: " + function);
        }
        gameObject.SetActive(false);
    }

    public void No()
    {
        gameObject.SetActive(false);
    }
}
