using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    
    public interface ITile
    {
        public Transform GetTransform();
        public IBoardManager GetBoardManager();

        public void Show();
        public void Hide();
        public ITileType GetTileData();
    }
    public enum TileTag { LOSBlocker }
}
