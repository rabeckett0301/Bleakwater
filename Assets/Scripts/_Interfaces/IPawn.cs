using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPawn
{
    public IInventory GetInventory();
    public GameObject GetModel();
    public void ActivateItem(ITile tile);
    public void ActivateItem(IItem item);
}

public interface IPawnInitializer
{
    public void SetBoardManager(IBoardManager manager);
}
