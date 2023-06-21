using Bleakwater;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IInventory
{
    public void AddItem(IItem item)
    {
        throw new NotImplementedException();
    }

    public List<IItem> GetItems()
    {
        throw new NotImplementedException();
    }

    public void RemoveItem(IItem item)
    {
        throw new NotImplementedException();
    }

    public void Subscribe(Action OnInventoryUpdated)
    {
        throw new NotImplementedException();
    }
}
