using Bleakwater;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTile_ContextGiver : PawnSpecificTile<ICharacter>
{
    public string Name;
    public string Type;
    public string Location;

    public Sprite Portrait;

    public List<string> Lines = new List<string>();
    public List<string> Option_1_Lines = new List<string>();
    public List<string> Option_2_Lines = new List<string>();

    private int CurrentIndex;

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

    protected override bool Activate(ICharacter user)
    {
        CurrentIndex = 0;
        user.DialogueManager.Draw_NPC(Name, Type, Location, Portrait);
        user.DialogueManager.Write(Lines[CurrentIndex]);
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        return true;
    }

    public void Respond(ICharacter character)
    {
        if (CurrentIndex < Lines.Count - 1)
        {
            character.DialogueManager.DisplayOption(Option_1_Lines[CurrentIndex], () => Activate(character));
            CurrentIndex++;
        }
        else
        {
            character.DialogueManager.DisplayOption(Option_1_Lines[CurrentIndex], () => EndDialogue(character));
        }
    }

    public void EndDialogue(ICharacter character)
    {
        character.DialogueManager.Close();
    }
}
