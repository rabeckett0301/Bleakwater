using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasicTile : MonoBehaviour, ITile
{
    public bool Activate(IPawn pawn)
    {
        return false;
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
