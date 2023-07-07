using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ItemTile : PawnSpecificTile<ICharacter>
{
    [SerializeField]
    public ITEM_Key _loot;

    protected override bool Activate(ICharacter character)
    {
        character.DialogueManager.Draw_Item(_loot.name, _loot.Icon, _loot.Description, _loot.Effect);
        character.KeyItemInventory.AddItem(_loot);
        return true;
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
