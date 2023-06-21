using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile : MonoBehaviour, ITile
{
    public IBoardManager GetBoardManager()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<TileTag> GetTags()
    {
        throw new System.NotImplementedException();
    }

    public ITileType GetTileData()
    {
        throw new System.NotImplementedException();
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
