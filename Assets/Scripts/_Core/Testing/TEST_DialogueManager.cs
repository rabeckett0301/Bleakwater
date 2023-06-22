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
        Text = this.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        this.transform.GetChild(1).gameObject.SetActive(false);

        string callText = "This is some test text that's pretty neat!";
        Write(callText);
    }

    public void Write(string text)
    {
        this.gameObject.SetActive(true);

        string currentText = "";

        for(int i = 0; i < text.Length; i++)
        {
            currentText += text[i];
            Text.text = currentText;
        }

        string option = "Cool!";
        DisplayOption(option);
    }

    public void DisplayOption(string text)
    {
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = text;

    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
