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
        protected abstract void Activate(TPawn pawn);

        public void Activate(IPawn pawn)
        {
            if (pawn is TPawn)
            {
                Activate((TPawn)pawn);
            }
            else
            {

                ActivateOnNonSpecificPawn(pawn);
            }
        }
        protected virtual void ActivateOnNonSpecificPawn(IPawn pawn)
        {
            Debug.Log("Pawn is not of type " + typeof(TPawn).Name);
        }



    }
}