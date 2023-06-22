using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bleakwater
{
    public class TestMoveTile : MonoBehaviour, ITile
    {
        [SerializeField]
        GameObject targetTile;
        [SerializeField]
        List<TileTag> tileTags;
        public void Activate()
        {
            IPawnTracker<ICharacter> ct = GetComponentInParent<IBoardManager>().GetCharacterTracker();
            IEnumerable<ICharacter> pawnsOnTile = ct.GetPawnsByTile(this);
            foreach(ICharacter c in pawnsOnTile)
            {
                ct.MovePawn(c, targetTile.GetComponent<ITile>());
                break;
            }
        }

        public IEnumerable<TileTag> GetTags()
        {
            return tileTags;
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void Hide()
        {
            throw new System.NotImplementedException();
        }

        public void Show()
        {
            throw new System.NotImplementedException();
        }


    }
}