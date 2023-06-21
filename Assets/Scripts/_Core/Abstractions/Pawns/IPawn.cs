
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface IPawn
    {
        public GameObject GetModel();
    }

    public interface IPawnInitializer
    {
        public void SetBoardManager(IBoardManager manager);
    }
    
    
}