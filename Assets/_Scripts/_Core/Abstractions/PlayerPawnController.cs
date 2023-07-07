using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Bleakwater
{
    public abstract class PlayerPawnController : MonoBehaviour 
    {
        [SerializeField]
        protected IControlTarget defaultControlTarget;
        protected IControlTarget currentControlTarget;
        public void ChangeControlTarget(IControlTarget controlTarget)
        {
            currentControlTarget = controlTarget;
        }
        public void RestoreControltarget()
        {
            currentControlTarget = defaultControlTarget;
        }
    }


    public interface IControlTarget
    {
        void Move(ITile target);
    }
}