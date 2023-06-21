using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public class TileItem : ITileItem
    {
        [SerializeField]
        private TileType tileType;

        public ITileType GetTileType()
        {
            return tileType;
        }

        public void Activate(ITileType tileType)
        {
            throw new System.NotImplementedException();
        }

        public GameObject GetIcon()
        {
            throw new System.NotImplementedException();
        }


    }
}