using Bleakwater;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IInventory
{
    List<IItem> items= new();
    public void Activate(ITile tile)
    {
        bool contains = false;
        List<ITileItem> activatableItems = new List<ITileItem>();
        foreach (IItem item in items)
        {

            if (typeof(ITileItem).IsAssignableFrom(item.GetType()))
            {

                activatableItems.Add( (ITileItem)item);
                contains = true;
            }
        }
        foreach (ITileItem tileItem in activatableItems)
        {
            tileItem.Activate(tile);
        }
        if (!contains)
        {
            tile.Activate();
        }
    }

    public void AddItem(IItem item)
    {
        items.Add(item);
    }

    public List<IItem> GetItems()
    {
        throw new NotImplementedException();
    }

    public ITileItem GetTileItem<ITile>()
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
