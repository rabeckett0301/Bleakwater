using Bleakwater;
using System;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TEST_DialogueManager : MonoBehaviour, IDialogueManager
{
    private TMP_Text Text;

    private void Start()
    {
        Text = this.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        this.gameObject.SetActive(false);
    }

    public void Draw(string Title, string Class, string Location)
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
