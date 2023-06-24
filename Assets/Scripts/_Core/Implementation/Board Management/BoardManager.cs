using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace Bleakwater {
    [RequireComponent(typeof(ITileGraph))]
    public class BoardManager : MonoBehaviour, IBoardManager
    {
        private ITileGraph _tileGraph;
        private IPawnTracker<ICharacter> _characterTracker = new PawnTracker<ICharacter>();
        private IPawnTracker<IViewport> _viewportTracker = new PawnTracker<IViewport>();



        private void Awake()
        {
            _tileGraph = GetComponent<ITileGraph>();
        }

        public ITileGraph GetTileGraph()
        {
            return _tileGraph;
        }
        public IPawnTracker<ICharacter> GetCharacterTracker()
        {
            return _characterTracker;
        }
        public IPawnTracker<IViewport> GetViewportTracker()
        {
            return _viewportTracker;
        }
    }


}
