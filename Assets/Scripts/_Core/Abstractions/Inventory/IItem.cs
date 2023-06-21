using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bleakwater
{
    public interface IItem
    {
        public GameObject GetIcon();
    }
    public interface ITileItem : IItem
    {

        public ITileType GetTileType();
        public void Activate(ITileType tileType);
    }
    public interface IUseableItem : IItem
    {
        public void Activate();
    }
    public interface IKeyItem : IItem
    {

    }
}