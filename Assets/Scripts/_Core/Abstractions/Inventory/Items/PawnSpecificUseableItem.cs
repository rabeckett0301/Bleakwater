using Bleakwater;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PawnSpecificUseableItem<TPawn> : IUseableItem where TPawn : IPawn
{
    public GameObject Icon => throw new System.NotImplementedException();

    public bool Activate(IPawn user)
    {
        if (user is TPawn)
        {
            return Activate(user);
        }
        else
        {
            return ActivateOnNonSpecificPawn(user);
        }
    }
    protected abstract bool Activate(TPawn user);
    protected virtual bool ActivateOnNonSpecificPawn(IPawn user)
    {
        Debug.Log("Pawn not of type " + typeof(TPawn).Name);
        return false;
    }
}
