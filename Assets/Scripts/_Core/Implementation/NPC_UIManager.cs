using Bleakwater;
using System;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_UIManager : MonoBehaviour, IDialogueManager
{
    private Transform Panel;

    private void Start()
    {
        Panel = this.transform;
        this.gameObject.SetActive(false);
    }

    public void SubscribeOnOpen()
    {
        throw new NotImplementedException();
    }

    public void Draw(string Title, string Class, string Location)
    {
        this.gameObject.SetActive(true);

        Panel.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Title;
    }

    public void Write(string text)
    {
        throw new NotImplementedException();
    }

    public void DisplayOption(string text, Action option)
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }

    public void SubscribeOnClose()
    {
        throw new NotImplementedException();
    }
}
