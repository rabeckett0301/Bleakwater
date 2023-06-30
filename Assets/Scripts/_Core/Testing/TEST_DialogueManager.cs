using Bleakwater;
using System;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TEST_DialogueManager : MonoBehaviour, IDialogueManager
{
    public GameObject DialoguePanel;
    public GameObject EventPanel;

    private TMP_Text Text;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Draw_NPC(string Title, string Class, string Location, Sprite Portrait)
    {

    }

    public void Draw_Event(string Title, Sprite Portrait, string Description, string Effect)
    {

    }

    public void Write(string text)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(StringBuilder(text));
    }

    public IEnumerator StringBuilder(string text)
    {
        string currentText = "";

        for (int i = 0; i < text.Length; i++)
        {
            currentText += text[i];
            Text.text = currentText;
            yield return new WaitForSeconds(0.02f);
        }

        yield return null;
    }

    public void AddOneShotListener(Action option)
    {
        this.transform.GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
        option.Invoke();
    }

    public void DisplayOption(string text, Action option)
    {
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => AddOneShotListener(option));
        this.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = text;

    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void SubscribeOnOpen()
    {
        throw new NotImplementedException();
    }

    public void SubscribeOnClose()
    {
        throw new NotImplementedException();
    }
}
