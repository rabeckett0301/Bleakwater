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

    public int CurrentIndex;

    private UI_TileManager TM;

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

        if (CurrentIndex < Lines.Count - 1)
        {
            user.DialogueManager.DisplayOption(Option_1_Lines[CurrentIndex], () => Respond(user));
            //user.DialogueManager.DisplayOption(Option_2_Lines[CurrentIndex], () => Respond(user));
        }

        user.DialogueManager.DisplayOption(Option_2_Lines[CurrentIndex], () => EndDialogue(user));

        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        CurrentIndex++;
        return true;
    }

    public void Respond(ICharacter character)
    {
        //CurrentIndex++;

        character.DialogueManager.Write(Lines[CurrentIndex]);

        if (CurrentIndex < Lines.Count - 1)
        {
            character.DialogueManager.DisplayOption(Option_1_Lines[CurrentIndex], () => Respond(character));
        }

        TM = GameObject.Find("Main UI").GetComponent<UI_TileManager>();
        TM.DisplayedOptions = 1;
        character.DialogueManager.DisplayOption(Option_2_Lines[CurrentIndex], () => EndDialogue(character));
        CurrentIndex++;

        /*if (CurrentIndex < Lines.Count - 1)
        {

        }
        else
        {
            character.DialogueManager.DisplayOption(Option_1_Lines[CurrentIndex], () => EndDialogue(character));
        }*/
    }

    public void EndDialogue(ICharacter character)
    {
        character.DialogueManager.Close_NPC();
    }
}
