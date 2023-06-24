using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ItemTile : PawnSpecificTile<ICharacter>
{
    [SerializeField]
    BoardManager BoardManager;

    [SerializeField]
    TestIgnoreMoveTileItem Loot;

    protected override void Activate(ICharacter character)
    {
        character.DialogueManager.Write("New item found!");
        character.DialogueManager.DisplayOption("Take",() => AddItemToCharacter(character));
    }

    private void AddItemToCharacter(ICharacter character)
    {
        character.DialogueManager.Close();
        character.Inventory.AddItem(Loot);
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
