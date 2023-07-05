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

    public Button Button1;
    public Button Button2;

    public int DisplayedOptions;

    public float Duration;

    private void Start()
    {
        DialoguePanel = this.transform.GetChild(1);
        EventPanel = this.transform.GetChild(2);

        Button1 = DialoguePanel.GetChild(4).gameObject.GetComponent<Button>();
        Button2 = DialoguePanel.GetChild(5).gameObject.GetComponent<Button>();

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

        DialoguePanel.GetChild(4).gameObject.SetActive(false);
        DialoguePanel.GetChild(5).gameObject.SetActive(false);

        StartCoroutine(this.Present_NPC());
    }

    private IEnumerator Present_NPC()
    {
        for (int i = 0; i < DialoguePanel.transform.childCount - 3; i++)
        {
            float newTime = 0;

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

        EventPanel.GetChild(0).gameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 0);
        EventPanel.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Title;

        EventPanel.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        EventPanel.GetChild(1).GetComponent<Image>().sprite = Portrait;

        EventPanel.GetChild(2).gameObject.GetComponent<TMP_Text>().color = new Color(1, 1, 1, 0);
        EventPanel.GetChild(2).gameObject.GetComponent<TMP_Text>().text = Description;

        EventPanel.GetChild(3).gameObject.GetComponent<TMP_Text>().color = new Color(1, 0, 0, 0);
        EventPanel.GetChild(3).gameObject.GetComponent<TMP_Text>().text = Effect;

        EventPanel.GetChild(4).gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 0);

        StartCoroutine(this.Present_Event());
    }

    private IEnumerator Present_Event()
    {
        for (int i = 0; i < EventPanel.transform.childCount; i++)
        {
            float newTime = 0;

            while (newTime < Duration)
            {
                if (EventPanel.GetChild(i).gameObject.GetComponent<TMP_Text>())
                {
                    if (i == 3)
                    {
                        EventPanel.GetChild(i).gameObject.GetComponent<TMP_Text>().color = Color.Lerp(new Color(1, 0, 0, 0), new Color(1, 0, 0, 1), newTime / Duration);
                    }
                    else
                    {
                        EventPanel.GetChild(i).gameObject.GetComponent<TMP_Text>().color = Color.Lerp(new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), newTime / Duration);
                    }
                }
                else
                {
                    EventPanel.GetChild(i).gameObject.GetComponent<Image>().color = Color.Lerp(new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), newTime / Duration);
                }

                newTime += Time.time;
                yield return null;
            }
        }
        yield return null;
    }

    public void Write(string text)
    {
        DisplayedOptions = 0;
        Button1.gameObject.SetActive(false);
        Button2.gameObject.SetActive(false);

        string newText = text;

        StartCoroutine(this.StringBuilder(newText));
    }

    private IEnumerator StringBuilder(string Line)
    {
        TMP_Text NPCText = DialoguePanel.GetChild(3).gameObject.GetComponent<TMP_Text>();
        NPCText.text = "''";

        for (int i = 0; i < Line.Length; i++)
        {
            NPCText.text += Line[i];
            yield return new WaitForSeconds(0.05f);
        }

        NPCText.text += "''";
        yield return null;
    }

    public void DisplayOption(string text, Action option)
    {
        switch (DisplayedOptions)
        {
            case 0:

                Button1.gameObject.SetActive(true);
                Button1.onClick.AddListener(() => AddOneShotListener(Button1, option));
                Button1.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = text;

                break;

            case 1:

                Button2.gameObject.SetActive(true);
                Button2.onClick.AddListener(() => AddOneShotListener(Button2, option));
                Button2.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = text;

                break;

            default:

                Debug.LogError("Only 2 options can be displayed");

                    break;
        }

        DisplayedOptions++;
    }

    public void AddOneShotListener(Button Target, Action option)
    {
        Target.onClick.RemoveAllListeners();
        option.Invoke();
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void SubscribeOnClose()
    {
        throw new NotImplementedException();
    }
}
