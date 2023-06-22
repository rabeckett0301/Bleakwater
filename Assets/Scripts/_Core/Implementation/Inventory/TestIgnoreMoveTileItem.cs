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


        public void Activate(ITile targetTile)
        {
            targetTile.GetTags();
            HashSet<TileTag> tHash = new(tileTags);
            HashSet<TileTag> targetHash = new(targetTile.GetTags());
            if(tHash.Overlaps(targetHash))
            {
                Debug.Log("Overlap! do nothing");
            }
            else
            {
                targetTile.Activate();
            }

           
        }

        public GameObject GetIcon()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TileTag> GetTileTags()
        {
            throw new System.NotImplementedException();
        }
    }
}