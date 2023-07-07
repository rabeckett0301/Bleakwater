using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface ICharacter : IPawn
    {
        public IDialogueManager DialogueManager { get; }
        public IInventory<ITileItem> TileItemInventory { get; }
        public IInventory<IUseableItem> UseableItemInventory { get; }
        public IInventory<IKeyItem> KeyItemInventory { get; }

    }
}