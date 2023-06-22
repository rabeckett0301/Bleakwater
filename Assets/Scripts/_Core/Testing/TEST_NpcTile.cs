using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_NpcTile : MonoBehaviour, ITile
{
    [SerializeField]
    BoardManager BoardManager;

    public void Activate()
    {
        BoardManager.GetDialogueManager().Write("Welcome to Bleakwater...");
        BoardManager.GetDialogueManager().DisplayOption("Listen", Respond);
    }

    public void Respond()
    {
        BoardManager.GetDialogueManager().Write("Your goal is at the end of the path.");
        BoardManager.GetDialogueManager().DisplayOption("Thanks.", EndDialogue);
    }

    public void EndDialogue()
    {
        Debug.Log("Ending talking");
        BoardManager.GetDialogueManager().Close();
    }

    public IEnumerable<TileTag> GetTags()
    {
        throw new System.NotImplementedException();
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Hide()
    {
        throw new System.NotImplementedException();
    }

    public void Show()
    {
        throw new System.NotImplementedException();
    }
}
