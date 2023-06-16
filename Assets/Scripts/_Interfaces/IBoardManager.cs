using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoardManager
{
    //The board manager should automaticaly show all of the tiles within eyesight of the players pawn
    //All tiles are hidden by default 
    public ITile GetClosestTile(Vector3 pos);
    public ITile GetClosestTileOfType(TileType tileType, Vector3 pos);
    public List<ITile> GetTilesInRadius(Vector3 pos, int radius);
    public List<ITile> GetTilesInRadiusOfType(TileType tileType, Vector3 pos, int radius);
    public List<ITile> GetTilesLOS(Vector3 pos, int radius);
    public List<IPawn> GetPawns();
    public void AddPawnToBoard(ITile location, IPawn pawn);
    public void RemovePawnFromBoard(IPawn pawn);
    public void AddViewport(ITile location, IViewport viewport);
    public void MovePawn(IPawn pawn, ITile location);
    public IDialogueManager GetDialogueManager();
}
