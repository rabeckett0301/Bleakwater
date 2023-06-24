using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface IGameMap
    {
        public IPawnTracker<ICharacter> GetCharacterTracker();
        public IPawnTracker<IViewport> GetViewportTracker();
        public ITileGraph GetTileGraph();


    }
}