using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace Bleakwater {
    [RequireComponent(typeof(ITileGraph))]
    public class BoardManager : MonoBehaviour, IBoardManager
    {
        [SerializeField]
        private ITileGraph _tileGraph;
        [SerializeField]
        private IDialogueManager _dialogueManager;

        private IPawnTracker<ICharacter> _characterTracker = new PawnTracker<ICharacter>();
        private IPawnTracker<IViewport> _viewportTracker = new PawnTracker<IViewport>();

        

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

        public IDialogueManager GetDialogueManager()
        {
            throw new System.NotImplementedException();
        }

    }


}
