using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TILE_Chest : PawnSpecificTile<ICharacter>
{
    public Elixirs_Template loot;

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
        user.UseableItemInventory.AddItem(loot);
        return true;
    }
}
