using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ItemTile : MonoBehaviour, ITile
{
    [SerializeField]
    BoardManager BoardManager;

    [SerializeField]
    TestIgnoreMoveTileItem Loot;

    public void Activate()
    {
        BoardManager.GetDialogueManager().Write("New item found!");
        BoardManager.GetDialogueManager().DisplayOption("Take", AddItemToCharacter);
    }

    private void AddItemToCharacter()
    {
        BoardManager.GetDialogueManager().Close();

        IEnumerable<ICharacter> Characters = BoardManager.GetCharacterTracker().GetPawnsByTile(this);

        foreach (ICharacter character in Characters)
        {
            character.            Inventory.AddItem(Loot);
        }
    }

    public IEnumerable<TileTag> Tags => new List<TileTag>();

    public Transform Transform => transform;

    public void Hide()
    {
        throw new System.NotImplementedException();
    }

    public void Show()
    {
        throw new System.NotImplementedException();
    }
}
