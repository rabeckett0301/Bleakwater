using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Bleakwater
{
    public class TestCharacter : MonoBehaviour, ICharacter, IControlTarget
    {


        [SerializeField] 
        GameObject boardManagerSource;
        IBoardManager boardManager;
        ITileGraph tileGraph;

        [SerializeField]
        Tile startTile;
        ITile targetTile;

        IInventory inventory = new Inventory();
        [SerializeField]
        TestIgnoreMoveTileItem ignoreMoveTileItem;
        private void Awake()
        {
            inventory.AddItem(ignoreMoveTileItem);



        }
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
            float speed = 25f;
            ITile currentTile = boardManager.GetCharacterTracker().GetTileByPawn(this);
             
            Vector3 moveDir = (targetTile.GetTransform().position + Vector3.up * 1.5f) - transform.position;
            if (moveDir.magnitude < Time.deltaTime * speed)
            {
                moving = false;
                transform.Translate(moveDir);
                boardManager.GetCharacterTracker().MovePawn(this, targetTile);
                inventory.Activate(targetTile);

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
            if (moving || targetTile == this.targetTile) return;
            moving = true;
            Debug.Log("Tile Selected");
            Debug.Log(this.targetTile);
            Debug.Log(targetTile);
            List<ITile> path = tileGraph.GetPathToTile(this.targetTile, targetTile);

            if (path != null && path.Count > 0)
            {
                this.targetTile = path[0];
            }
        }
    }
}
