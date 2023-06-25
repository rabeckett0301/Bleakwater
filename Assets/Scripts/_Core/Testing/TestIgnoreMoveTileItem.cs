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
        private Sprite _icon;
        [SerializeField]
        private List<TileTag> _tileTags;


        public Sprite Icon => _icon;
        public IEnumerable<TileTag> TileTags => throw new System.NotImplementedException();


        public bool Activate(ITile targetTile, IPawn pawn)
        {
            HashSet<TileTag> tHash = new(_tileTags);
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


    }
}