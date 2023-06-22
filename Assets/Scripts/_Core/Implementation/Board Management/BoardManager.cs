using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 namespace Bleakwater {
    [RequireComponent(typeof(ITileGraph))]
    public class BoardManager : MonoBehaviour, IBoardManager
    {
        [SerializeField]
        private GameObject dialogueGO;
        private ITileGraph _tileGraph;

        private IDialogueManager _dialogueManager;

        private IPawnTracker<ICharacter> _characterTracker = new PawnTracker<ICharacter>();
        private IPawnTracker<IViewport> _viewportTracker = new PawnTracker<IViewport>();



        private void Awake()
        {
            _tileGraph = GetComponent<ITileGraph>();
            _dialogueManager = dialogueGO.GetComponent<IDialogueManager>();
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

        public IDialogueManager GetDialogueManager()
        {
            return _dialogueManager;
        }

    }


}
