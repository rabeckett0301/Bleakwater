using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bleakwater
{
    public class PawnTracker<TPawn> : IPawnTracker<TPawn> where TPawn : IPawn
    {
        Dictionary<TPawn, ITile> pawnToTileMap = new Dictionary<TPawn, ITile>();
        Dictionary<ITile, HashSet<TPawn>> tileToPawnsMap = new Dictionary<ITile, HashSet<TPawn>>();
        public bool AddPawn(ITile tile, TPawn pawn)
        {
            if (!pawnToTileMap.ContainsKey(pawn))
            {
                pawnToTileMap[pawn] = tile;
                if (!tileToPawnsMap.ContainsKey(tile))
                {
                    tileToPawnsMap[tile] = new HashSet<TPawn>();
                }

                tileToPawnsMap[tile].Add(pawn);
                return true;
            }
            else
            {
                Debug.LogError("Attempting to add duplicate pawn! " + pawn);
                return false;
            }
        }
        public bool RemovePawn(TPawn pawn)
        {
            if (pawnToTileMap.ContainsKey(pawn))
            {
                ITile tile = pawnToTileMap[pawn];
                pawnToTileMap.Remove(pawn);

                if (tileToPawnsMap.ContainsKey(tile))
                {
                    tileToPawnsMap[tile].Remove(pawn);
                    if (tileToPawnsMap[tile].Count == 0)
                    {
                        tileToPawnsMap.Remove(tile);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public ITile GetTileByPawn(TPawn pawn)
        {
            pawnToTileMap.TryGetValue(pawn, out ITile tile);
            return tile;
        }

        public IEnumerable<TPawn> GetPawnsByTile(ITile tile)
        {
            if (tileToPawnsMap.TryGetValue(tile, out HashSet<TPawn> pawns))
            {
                return pawns;
            }
            else
            {
                return Enumerable.Empty<TPawn>();  
            }
        }
        public IEnumerable<TPawn> GetPawns()
        {
            return pawnToTileMap.Keys;
        }

        public bool MovePawn(TPawn pawn, ITile newTile)
        {
            bool isValidMove = false;
            if (pawnToTileMap.ContainsKey(pawn))
            {
                ITile currentTile = pawnToTileMap[pawn];

                if (currentTile != newTile)
                {
                    tileToPawnsMap[currentTile].Remove(pawn);
                    if (tileToPawnsMap[currentTile].Count == 0)
                    {
                        tileToPawnsMap.Remove(currentTile);
                    }

                    pawnToTileMap[pawn] = newTile;
                    if (!tileToPawnsMap.ContainsKey(newTile))
                    {
                        tileToPawnsMap[newTile] = new HashSet<TPawn>();
                    }
                    tileToPawnsMap[newTile].Add(pawn);
                    isValidMove = true;
                }
            }
            return isValidMove;
        }

    }
}
