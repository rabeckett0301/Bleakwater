using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    [System.Serializable]
    public class TestIgnoreMoveTileItem : ITileItem
    {
        [SerializeField]
        private List<TileTag> tileTags;


        public bool Activate(ITile targetTile, IPawn pawn)
        {
            HashSet<TileTag> tHash = new(tileTags);
            HashSet<TileTag> targetHash = new(targetTile.Tags);
            if(tHash.Overlaps(targetHash))
            {
                Debug.Log("Overlap! do nothing");
                return true;
            }
            else
            {
                return false;
            }

           
        }

        public GameObject Icon => throw new System.NotImplementedException();

        public IEnumerable<TileTag> TileTags => throw new System.NotImplementedException();
    }
}