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

    public Image Portrait;

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
        user.DialogueManager.Draw(Name, Type, Location);

        return true;
    }
}
