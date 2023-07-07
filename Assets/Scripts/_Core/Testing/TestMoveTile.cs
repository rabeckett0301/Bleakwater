using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bleakwater
{
    public class TestMoveTile : PawnSpecificTile<TestCharacter>
    {
        [SerializeField]
        GameObject targetTile;
        [SerializeField]
        List<TileTag> tileTags;

        [SerializeField]
        private ITEM_Key Key;

        protected override bool Activate(TestCharacter character)
        {
            if (!character.KeyItemInventory.GetItems().Contains(Key))
            {
                IPawnTracker<ICharacter> ct = GetComponentInParent<IGameMap>().GetCharacterTracker();

                character.ActionPoints++;
                character.Health -= 50;

                ct.MovePawn(character, targetTile.GetComponent<ITile>());
                return true;
            }
            else
            {
                return false;
            }
        }

        public override IEnumerable<TileTag> Tags => tileTags;

        public override Transform Transform => transform;

        public override void Hide()
        {
            throw new System.NotImplementedException();
        }

        public override void Show()
        {
            throw new System.NotImplementedException();
        }
    }
}