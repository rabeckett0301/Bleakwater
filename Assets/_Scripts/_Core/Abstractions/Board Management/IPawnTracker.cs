using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPawnTracker<TPawn> where TPawn : IPawn
{
    public bool AddPawn(ITile tile, TPawn pawn);
    public bool RemovePawn(TPawn pawn);

    public IEnumerable<TPawn> GetPawns();
    public ITile GetTileByPawn(TPawn pawn);
    public IEnumerable<TPawn> GetPawnsByTile(ITile tile);

    public bool MovePawn(TPawn pawn, ITile tile);
}
