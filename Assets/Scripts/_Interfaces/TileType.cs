using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileType : ScriptableObject
{
    //Runtime data should never bes saved in this object.
    //If line of site(LOS) is blocked, this tile will be visible, but all tiles behind it will not be.
    [SerializeField]
    private List<ITileTag> tileTags;
    [SerializeField]
    private GameObject model;

    public abstract void TileAction(ITile tile);
}

public enum ITileTag { LOSBlocker, IgnoreLOS }
