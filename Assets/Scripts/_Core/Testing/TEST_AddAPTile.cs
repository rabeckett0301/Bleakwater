using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_AddAPTile : MonoBehaviour, ITile
{
    [SerializeField]
    TestCharacter Character;

    private bool HasTaken = false;

    public void Activate()
    {
        if(!HasTaken)
        {
            Character.ActionPoints += 2;
            HasTaken = true;
        }
    }

    public IEnumerable<TileTag> GetTags()
    {
        return new List<TileTag>();
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Hide()
    {
        throw new System.NotImplementedException();
    }

    public void Show()
    {
        throw new System.NotImplementedException();
    }
}
