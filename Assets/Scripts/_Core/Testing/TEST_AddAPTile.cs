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

    public IEnumerable<TileTag> Tags => new List<TileTag>();

    public Transform Transform => transform;

    public void Hide()
    {
        throw new System.NotImplementedException();
    }

    public void Show()
    {
        throw new System.NotImplementedException();
    }
}
