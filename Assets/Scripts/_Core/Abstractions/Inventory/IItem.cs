using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bleakwater
{
    public interface IItem
    {
        public GameObject Icon { get; }
    }
    public interface ITileItem : IItem
    {
        public IEnumerable<TileTag> TileTags { get; }

        public void Activate(ITile targetTile);
    }
    public interface IUseableItem : IItem
    {
        public void Activate();
    }
    public interface IKeyItem : IItem
    {

    }
}