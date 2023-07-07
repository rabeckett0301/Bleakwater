using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_LostSouls : PawnSpecificTile<TestCharacter>
{
    public string Title;
    public Sprite Portrait;
    public string Description;
    public string Effect;

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

    protected override bool Activate(TestCharacter user)
    {
        user.DialogueManager.Draw_Event(Title, Portrait, Description, Effect);

        user.ActionPoints -= 10;
        return true;
    }
}
