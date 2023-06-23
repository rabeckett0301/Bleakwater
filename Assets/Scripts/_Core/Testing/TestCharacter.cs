using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Bleakwater
{
    public class TestCharacter : MonoBehaviour, ICharacter, IControlTarget
    {
        public int ActionPoints;

        [SerializeField] 
        GameObject boardManagerSource;
        IBoardManager boardManager;
        ITileGraph tileGraph;

        [SerializeField]
        Tile startTile;
        ITile targetTile;

        IInventory inventory = new Inventory();

        private void Start()
        {
            boardManager = boardManagerSource.GetComponent<IBoardManager>();
            tileGraph = boardManager.GetTileGraph();
            boardManager.GetCharacterTracker().AddPawn(startTile, this);
        }
        bool moving = false;
        private void Update()
        {
            UpdateCharacterTile();
            MoveToTargetTile();
        }

        private void UpdateCharacterTile()
        {
            ITile currentTile = boardManager.GetCharacterTracker().GetTileByPawn(this);
            if (currentTile != targetTile && moving == false)
            {
                transform.position = currentTile.GetTransform().position + Vector3.up * 1.5f;
                targetTile = currentTile;
            }
        }

        private void MoveToTargetTile()
        {
            if (moving == false) return;
            ITile currentTile = boardManager.GetCharacterTracker().GetTileByPawn(this);
            List<ITile> path = tileGraph.GetPathToTile(currentTile, targetTile);
            float speed = 25f;
 
            
            if (path.Count > 0)
            {
                Vector3 moveDir = (path[0].GetTransform().position + Vector3.up * 1.5f) - transform.position;
                if (moveDir.magnitude < Time.deltaTime * speed)
                {
                    ActionPoints--;
                    transform.Translate(moveDir);
                    boardManager.GetCharacterTracker().MovePawn(this, path[0]);
                    inventory.Activate(path[0]);
                    currentTile = boardManager.GetCharacterTracker().GetTileByPawn(this);
                    if (currentTile != path[0]||ActionPoints<=0)
                    {
                        moving = false;
                    }

                }
                else
                {
                    moveDir = moveDir.normalized * speed * Time.deltaTime;
                    transform.Translate(moveDir);
                }
            }
            else
            {
                moving = false;
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
            if (ActionPoints > 0)
            {
                if (moving || targetTile == this.targetTile) return;
                moving = true;
                Debug.Log("Tile Selected");
                Debug.Log(this.targetTile);
                Debug.Log(targetTile);
                List<ITile> path = tileGraph.GetPathToTile(this.targetTile, targetTile);

                if (path != null && path.Count > 0)
                {
                    this.targetTile = targetTile;
                }
            }
        }
    }
}
