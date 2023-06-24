using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_AddAPTile : PawnSpecificTile<TestCharacter>
{
    private bool HasTaken = false;

    protected override void Activate(TestCharacter testCharacter)
    {
        if (!HasTaken)
        {
            testCharacter.ActionPoints += 2;
            HasTaken = true;
        }
    }

    protected override void ActivateOnNonSpecificPawn(IPawn pawn)
    {
        throw new System.NotImplementedException();
    }


    public override IEnumerable<TileTag> Tags => new List<TileTag>();

    public override Transform Transform => transform;

    public override void Hide()
    {
        throw new System.NotImplementedException();
    }

    public override void Show()
    {
        throw new System.NotImplementedException();
    }


}
