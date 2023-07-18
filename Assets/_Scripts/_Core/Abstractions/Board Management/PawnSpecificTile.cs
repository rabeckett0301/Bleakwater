using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public abstract class PawnSpecificTile<TPawn> : MonoBehaviour, ITile where TPawn : IPawn
    {
        public  abstract IEnumerable<TileTag> Tags { get; }

        public abstract Transform Transform { get; }
        public abstract void Hide();
        public abstract void Show();

        public bool Activate(IPawn user)
        {
            if (user is TPawn)
            {
                return Activate((TPawn)user);
            }
            else
            {

                return ActivateOnNonSpecificPawn(user);
            }
        }
        protected abstract bool Activate(TPawn user);

        protected virtual bool ActivateOnNonSpecificPawn(IPawn user)
        {
            Debug.Log("Pawn is not of type " + typeof(TPawn).Name);
            return false;
        }
    }
}