using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface IBoardManager
    {
        //The board manager should automaticaly show all of the tiles within eyesight of the players pawn
        //All tiles are hidden by default 
        //add events to the Pawn Trackers
        public IPawnTracker<ICharacter> GetCharacterTracker();
        public IPawnTracker<IViewport> GetViewportTracker();

        public ITileGraph GetTileGraph();
        public IDialogueManager GetDialogueManager();
    }
}