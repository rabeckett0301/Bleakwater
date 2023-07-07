using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Testing
{
    public class TileGraphTest : MonoBehaviour
    {
        [SerializeField]
        private GameObject debugNode1;
        [SerializeField]
        private GameObject debugNode2;
        void Start()
        {
            TileGraph tileGraph = GetComponent<TileGraph>();

            IEnumerable<ITile> path = tileGraph.GetPathToTile(debugNode1.GetComponent<ITile>(), debugNode2.GetComponent<ITile>());
            Debug.Log("Print path from " + debugNode1 + " to  " + debugNode2);
            if (path != null)
            {
                foreach (ITile tile in path)
                {
                    tile.                    Transform.GetComponent<Renderer>().material.color = Color.green;
                    Debug.Log(tile);
                }
            }
            else
            {
                Debug.Log("No path found");
            }
        }

    }
}
