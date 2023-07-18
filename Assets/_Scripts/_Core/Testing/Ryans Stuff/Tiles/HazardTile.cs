using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hazard Tile", menuName = "Scriptable Objects/Tiles/New Hazard Tile", order = 1)]

public class HazardTile : PawnSpecificTile<TestCharacter>
{
    public Sprite Portrait;
    public string Description;

    [TextArea]
    public string Effect;

    public int HealthEffect;
    public int APEffect;

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
        user.DialogueManager.Draw_Event(this.gameObject.name, Portrait, Description, Effect);

        Debug.Log("Activating Effect: " + this.gameObject.name +  "!");

        user.ActionPoints -= APEffect;
        user.Health -= HealthEffect;

        return true;
    }
}
