using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    public List<IItem> GetItems();
    public void AddItem(IItem item);
    public void RemoveItem(IItem item);
    public void Subscribe(Action OnInventoryUpdated);

}
