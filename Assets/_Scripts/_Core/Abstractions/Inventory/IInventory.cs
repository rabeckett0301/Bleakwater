
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface IInventory<TItem> where TItem : IItem//make a different inventory for each type of item
    {
        public List<TItem> GetItems();
        public void AddItem(TItem item);
        public void RemoveItem(TItem item);
        public void SubscribeToItemAdded(Action<TItem> OnInventoryUpdated);
        public void SubscribeToItemRemoved(Action<TItem> OnInventoryUpdated);

    }


}