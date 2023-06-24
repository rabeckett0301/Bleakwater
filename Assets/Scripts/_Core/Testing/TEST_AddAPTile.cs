using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_AddAPTile : PawnSpecificTile<TestCharacter>
{
    private bool HasTaken = false;

    protected override bool Activate(TestCharacter testCharacter)
    {
        if (!HasTaken)
        {
            testCharacter.ActionPoints += 2;
            HasTaken = true;
            return true;
        }
        else
        {
            return false;
        }
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
