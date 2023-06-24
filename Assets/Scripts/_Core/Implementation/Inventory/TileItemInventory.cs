using Bleakwater;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileItemInventory: IInventory<ITileItem>
{
    List<ITileItem> items= new();
    public void Activate(ITile tile, IPawn pawn)
    {
        bool contains = false;
        foreach (ITileItem tileItem in items)
        { 
            contains = tileItem.Activate(tile, pawn);
        }
        if (!contains)
        {
            tile.Activate(pawn);
        }
    }

    public void AddItem(ITileItem item)
    {
        items.Add(item);
    }

    public List<ITileItem> GetItems()
    {
        throw new NotImplementedException();
    }

    public ITileItem GetTileItem<ITile>()
    {
        throw new NotImplementedException();
    }

    public void RemoveItem(ITileItem item)
    {
        throw new NotImplementedException();
    }

    public void Subscribe(Action OnInventoryUpdated)
    {
        throw new NotImplementedException();
    }

    public void SubscribeToItemAdded(Action<ITileItem> OnInventoryUpdated)
    {
        throw new NotImplementedException();
    }

    public void SubscribeToItemRemoved(Action<ITileItem> OnInventoryUpdated)
    {
        throw new NotImplementedException();
    }
}
