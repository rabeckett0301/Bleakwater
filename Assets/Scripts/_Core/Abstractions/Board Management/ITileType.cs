using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITileType
{
    public IEnumerable<TileTag> GetTags();
    public void Activate();
}
