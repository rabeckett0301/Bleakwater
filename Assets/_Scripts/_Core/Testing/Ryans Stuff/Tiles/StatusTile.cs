using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusTile : PawnSpecificTile<TestCharacter>
{
    public Sprite Portrait;
    public string Description;

    [TextArea]
    public string Effect;

    public int Turns;
    public int StrengthEffect;
    public int AgilityEffect;
    public int WisdomEffect;
    public int FocusEffect;
    public int DesireEffect;
    public int TemperanceEffect;

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

        Debug.Log("Activating Effect: " + this.gameObject.name + "!");

        user.Strength -= StrengthEffect;
        user.Agility -= AgilityEffect;
        user.Wisdom -= WisdomEffect;
        user.Focus -= FocusEffect;
        user.Desire -= DesireEffect;
        user.Temperance -= TemperanceEffect;

        return true;
    }
}
