using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface ITileGraph
    {
        public bool AddTile(ITile tile);
        public bool RemoveTile(ITile tile);
        
        public IEnumerable<ITile> GetAllTiles();
        public IEnumerable<ITile> GetTilesInRange(ITile location, int range);
        public IEnumerable<ITile> GetTilesInRangeLOS(ITile location, int range);
        public List<ITile> GetPathToTile(ITile startTile, ITile goalTile);

        public ITile GetClosestTileOfType<TTile>(Vector3 pos) where TTile : ITile; 
        public IEnumerable<ITile> GetTilesInRadiusOfType<TTile>(Vector3 pos, int radius) where TTile : ITile;
        public IEnumerable<ITile> GetTilesOfType<TTile>() where TTile : ITile;
    }
}