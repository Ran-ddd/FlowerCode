using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTalk : MonoBehaviour
{
    private Global global = Global.Instance;
    public GameObject talkBoxUI;
    private TalkBox talkBox;

    void Start()
    {
        talkBox = talkBoxUI.GetComponent<TalkBox>();
        Talk();
    }
    private void Talk()
    {
        talkBoxUI.SetActive(true);
        talkBox.sprite = global.LoadCharacterHeadSpite("Girl");
        talkBox.textAsset = global.LoadCharacterTextAsset("Girl");
        talkBox.Show();
    }
}
