using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Elixir", menuName = "Scriptable Objects/Items/New Elixir Item", order = 2)]

public class Elixirs_Template : PawnSpecificUseableItem<TestCharacter>
{
    public int HealthEffect;
    public int APEffect;

    public Sprite icon;

    public override Sprite Icon => icon;

    protected override bool Activate(TestCharacter user)
    {
        user.Health += this.HealthEffect;
        user.ActionPoints += this.APEffect;

        user.UseableItemInventory.RemoveItem(this);
        return true;
    }
}
