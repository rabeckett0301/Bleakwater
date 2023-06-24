using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    
    public interface ITile
    {
        public IEnumerable<TileTag> Tags { get; }

        public Transform Transform { get; }

        public void Show();
        public void Hide();
        public void Activate();
    }
    public enum TileTag { LOSBlocker, Move }
}
