using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface ICharacter : IPawn
    {
        public IDialogueManager DialogueManager { get; }
        public IInventory Inventory { get; }
        public void ActivateItem(ITile tile);
        public void ActivateItem(IItem item);
    }
}