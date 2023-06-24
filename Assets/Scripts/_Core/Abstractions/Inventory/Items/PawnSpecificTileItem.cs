using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PawnSpecificTileItem<TPawn> : ITileItem where TPawn : IPawn
{
    public IEnumerable<TileTag> TileTags => throw new System.NotImplementedException();

    public GameObject Icon => throw new System.NotImplementedException();

    public bool Activate(ITile targetTile, IPawn user)
    {
        if(user is TPawn)
        {
            return Activate (targetTile, user);
        }
        else
        {
            return ActivateOnNonSpecificPawn(user);
        }
    }
    protected abstract bool Activate(ITile targetTile, TPawn user);
    protected virtual bool ActivateOnNonSpecificPawn(IPawn user)
    {
        Debug.Log("Pawn is not of type " + typeof(TPawn).Name);
        return false;
    }
}
