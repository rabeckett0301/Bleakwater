using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Bleakwater
{
    public class TestCharacter : MonoBehaviour, ICharacter, IControlTarget
    {

        IInventory inventory = new Inventory();

        [SerializeField]
        TileGraph tileGraph;

        [SerializeField]
        Tile startTile;
        ITile currentTile;
        private void Awake()
        {
            currentTile = startTile;
        }
        bool moving = false;
        private void Update()
        {

            float speed = 25f;
            Vector3 moveDir = (currentTile.GetTransform().position + Vector3.up * 1.5f) - transform.position;
            if (moveDir.magnitude < Time.deltaTime * speed)
            {
                moving = false;
                transform.Translate(moveDir);
            }
            else
            {
                moveDir = moveDir.normalized * speed * Time.deltaTime;
                transform.Translate(moveDir);
            }
        }
        public void ActivateItem(ITile tile)
        {
            throw new System.NotImplementedException();
        }

        public void ActivateItem(IItem item)
        {
            throw new System.NotImplementedException();
        }

        public IInventory GetInventory()
        {
            return inventory;
        }

        public GameObject GetModel()
        {
            throw new System.NotImplementedException();
        }

        public void Move(ITile targetTile)
        {
            if (moving) return;
            moving = true;
            Debug.Log("Tile Selected");
            List<ITile> path = tileGraph.GetPathToTile(currentTile, targetTile);

            if (path != null && path.Count > 0)
            {
                currentTile = path[0];
            }
        }
    }
}
