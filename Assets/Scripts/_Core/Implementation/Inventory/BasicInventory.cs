using Bleakwater;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInventory<TItem> : IInventory<TItem> where TItem : IItem
{
    private List<TItem> _inventory = new();
    public void AddItem(TItem item)
    {
        _inventory.Add(item);
    }

    public List<TItem> GetItems()
    {
        return _inventory;
    }

    public void RemoveItem(TItem item)
    {
        _inventory.Remove(item);
    }

    public void SubscribeToItemAdded(Action<TItem> OnInventoryUpdated)
    {
        throw new NotImplementedException();
    }

    public void SubscribeToItemRemoved(Action<TItem> OnInventoryUpdated)
    {
        throw new NotImplementedException();
    }
}
