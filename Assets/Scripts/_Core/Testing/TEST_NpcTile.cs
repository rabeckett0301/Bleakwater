using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_NpcTile : MonoBehaviour, ITile
{
    [SerializeField]
    BoardManager BoardManager;

    public List<string> TextPrompts = new List<string>();
    public List<string> ButtonPrompts = new List<string>();

    int CurrentIndex;

    public void Activate()
    {
        Debug.Log("CURRENT INDEX: " + CurrentIndex);
        BoardManager.GetDialogueManager().Write(TextPrompts[CurrentIndex]);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        Respond();
    }

    public void Respond()
    {
        if (CurrentIndex < TextPrompts.Count - 1)
        {
            BoardManager.GetDialogueManager().DisplayOption(ButtonPrompts[CurrentIndex], Activate);
            CurrentIndex++;
        }
        else
        {
            BoardManager.GetDialogueManager().DisplayOption(ButtonPrompts[CurrentIndex], EndDialogue);
        } 
    }

    public void EndDialogue()
    {
        Debug.Log("Ending talking");
        BoardManager.GetDialogueManager().Close();
    }

    public IEnumerable<TileTag> Tags => new List<TileTag>();

    public Transform Transform => transform;

    public void Hide()
    {
        throw new System.NotImplementedException();
    }

    public void Show()
    {
        throw new System.NotImplementedException();
    }
}
