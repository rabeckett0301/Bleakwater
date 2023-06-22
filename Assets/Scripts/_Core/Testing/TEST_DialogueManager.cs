using Bleakwater;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TEST_DialogueManager : MonoBehaviour, IDialogueManager
{
    private TMP_Text Text;

    private void Start()
    {
        Text = this.GetComponent<TMP_Text>();
        Open();
    }

    public void Open()
    {
        this.gameObject.SetActive(true);

        string callText = "This is some test text that's pretty neat!";
        Write(callText);
    }

    public void Write(string text)
    {
        string currentText = "";

        for(int i = 0; i < text.Length; i++)
        {
            currentText += text[i];
            Text.text = currentText;
        }
    }

    public void DisplayOption(string text, Action option)
    {
        

    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
