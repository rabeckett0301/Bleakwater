using Bleakwater;
using System;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TileManager : MonoBehaviour, IDialogueManager
{
    public Transform DialoguePanel;
    public Transform EventPanel;

    public float Duration;
    public float newTime;

    private void Start()
    {
        DialoguePanel = this.transform.GetChild(1);
        EventPanel = this.transform.GetChild(2);

        DialoguePanel.gameObject.SetActive(false);
        EventPanel.gameObject.SetActive(false);
    }

    public void SubscribeOnOpen()
    {
        throw new NotImplementedException();
    }

    public void Draw_NPC(string Title, string Class, string Location, Sprite Portrait)
    {
        DialoguePanel.gameObject.SetActive(true);

        DialoguePanel.GetChild(0).gameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 0);
        DialoguePanel.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Title;

        DialoguePanel.GetChild(1).gameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 0);
        DialoguePanel.GetChild(1).gameObject.GetComponent<TMP_Text>().text = (Class + " - " + Location);

        DialoguePanel.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        DialoguePanel.GetChild(2).gameObject.GetComponent<Image>().sprite = Portrait;

        DialoguePanel.GetChild(5).gameObject.SetActive(false);
        DialoguePanel.GetChild(6).gameObject.SetActive(false);

        StartCoroutine(this.Present_NPC());
    }

    private IEnumerator Present_NPC()
    {
        for (int i = 0; i < DialoguePanel.transform.childCount - 4; i++)
        {
            Debug.Log(i);

            newTime = 0;

            while (newTime < Duration)
            {
                if (DialoguePanel.GetChild(i).gameObject.GetComponent<TMP_Text>())
                {
                    DialoguePanel.GetChild(i).gameObject.GetComponent<TMP_Text>().color = Color.Lerp(new Color(1,1,1,0), new Color(1, 1, 1, 1), newTime / Duration);
                }
                else
                {
                    DialoguePanel.GetChild(i).gameObject.GetComponent<Image>().color = Color.Lerp(new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), newTime / Duration);
                }

                newTime += Time.time;
                yield return null;
            }
        }
        yield return null;
    }

    public void Draw_Event(string Title, Sprite Portrait, string Description, string Effect)
    {
        EventPanel.gameObject.SetActive(true);

        EventPanel.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Title;
        EventPanel.GetChild(1).GetComponent<Image>().sprite = Portrait;
        EventPanel.GetChild(2).gameObject.GetComponent<TMP_Text>().text = Description;
        EventPanel.GetChild(3).gameObject.GetComponent<TMP_Text>().text = Effect;
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
