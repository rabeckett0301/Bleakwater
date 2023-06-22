using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile : MonoBehaviour, ITile
{
    public void Activate()
    {
        Debug.Log("Ding");
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