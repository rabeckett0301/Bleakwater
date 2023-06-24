using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile : MonoBehaviour, ITile
{
    public void Activate()
    {
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
