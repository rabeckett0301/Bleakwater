using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface IViewport : IPawn
    {
        public int GetViewingDistance();
    }
}