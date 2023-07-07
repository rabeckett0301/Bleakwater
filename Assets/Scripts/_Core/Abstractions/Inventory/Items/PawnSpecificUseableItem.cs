using Bleakwater;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PawnSpecificUseableItem<TPawn> : ScriptableObject, IUseableItem where TPawn : IPawn
{
    public abstract Sprite Icon { get; }

    public bool Activate(IPawn user)
    {
        if (user is TPawn)
        {
            return Activate((TPawn)user);
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
