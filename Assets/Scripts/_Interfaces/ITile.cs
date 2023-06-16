using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITile
{
    public Transform GetTransform();
    public TileType GetTileType();
    public IPawn GetPawn();
    public bool SetPawn(IPawn pawn);

}
