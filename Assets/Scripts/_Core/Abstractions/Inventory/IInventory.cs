
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface IInventory//make a different inventory for each type of item
    {

        public void Activate(ITile tile,IPawn pawn);
        public List<IItem> GetItems();
        public ITileItem GetTileItem<ITile>();
        public void AddItem(IItem item);
        public void RemoveItem(IItem item);
        public void Subscribe(Action OnInventoryUpdated);

    }
}