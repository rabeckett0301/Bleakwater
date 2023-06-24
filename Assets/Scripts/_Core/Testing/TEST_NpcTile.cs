using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TEST_NpcTile : PawnSpecificTile<ICharacter>
{
    [SerializeField]
    BoardManager BoardManager;

    public List<string> TextPrompts = new List<string>();
    public List<string> ButtonPrompts = new List<string>();

    int CurrentIndex;

    protected override bool Activate(ICharacter character)
    {
        Debug.Log("CURRENT INDEX: " + CurrentIndex);
        character.DialogueManager.Write(TextPrompts[CurrentIndex]);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        Respond(character);
        return true;
    }

    public void Respond(ICharacter character)
    {
        if (CurrentIndex < TextPrompts.Count - 1)
        {
            character.DialogueManager.DisplayOption(ButtonPrompts[CurrentIndex],() => Activate(character));
            CurrentIndex++;
        }
        else
        {
            character.DialogueManager.DisplayOption(ButtonPrompts[CurrentIndex], () => EndDialogue(character));
        } 
    }

    public void EndDialogue(ICharacter character)
    {
        Debug.Log("Ending talking");
        character.DialogueManager.Close();
    }

    public override IEnumerable<TileTag> Tags => new List<TileTag>();

    public override Transform Transform => transform;

    public override void Hide()
    {
        throw new System.NotImplementedException();
    }

    public override void Show()
    {
        throw new System.NotImplementedException();
    }
}
