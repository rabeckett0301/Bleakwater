using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Bleakwater
{
    public class TestCharacter : MonoBehaviour, ICharacter, IControlTarget
    {
        public IDialogueManager DialogueManager => _dialogueManager;

        public IInventory<ITileItem> TileItemInventory => _tileItemInventory;

        public IInventory<IUseableItem> UseableItemInventory => _useableItemInventory;

        public IInventory<IKeyItem> KeyItemInventory => _keyItemInventory;

        public int ActionPoints;
        public int Health;

        public int Strength;
        public int Agility;
        public int Wisdom;
        public int Focus;
        public int Desire;
        public int Temperance;

        [SerializeField]
        private TEST_DialogueManager _dialogueManager;

        private ITileGraph _tileGraph;

        [SerializeField]
        private BasicTile _startTile;
        private ITile _targetTile;

        TileItemInventory _tileItemInventory = new TileItemInventory();
        IInventory<IUseableItem> _useableItemInventory = new BasicInventory<IUseableItem>();
        IInventory<IKeyItem> _keyItemInventory = new BasicInventory<IKeyItem>();



        private void Start()
        {

            _tileGraph = ServiceLocator.GameMap.GetTileGraph();
            ServiceLocator.GameMap.GetCharacterTracker().AddPawn(_startTile, this);
        }
        bool moving = false;
        private void Update()
        {
            UpdateCharacterTile();
            MoveToTargetTile();
        }

        private void UpdateCharacterTile()
        {
            ITile currentTile = ServiceLocator.GameMap.GetCharacterTracker().GetTileByPawn(this);
            if (currentTile != _targetTile && moving == false)
            {
                transform.position = currentTile.Transform.position + Vector3.up * 1.5f;
                _targetTile = currentTile;
            }
        }

        private void MoveToTargetTile()
        {
            if (moving == false) return;
            ITile currentTile = ServiceLocator.GameMap.GetCharacterTracker().GetTileByPawn(this);
            List<ITile> path = _tileGraph.GetPathToTile(currentTile, _targetTile);
            float speed = 25f;
 
            
            if (path.Count > 0)
            {
                Vector3 moveDir = (path[0].Transform.position + Vector3.up * 1.5f) - transform.position;
                if (moveDir.magnitude < Time.deltaTime * speed)
                {
                    ActionPoints--;
                    transform.Translate(moveDir);
                    ServiceLocator.GameMap.GetCharacterTracker().MovePawn(this, path[0]);
                    _tileItemInventory.Activate(path[0], this);
                    currentTile = ServiceLocator.GameMap.GetCharacterTracker().GetTileByPawn(this);
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




        public GameObject GetModel()
        {
            throw new System.NotImplementedException();
        }

        public void Move(ITile targetTile)
        {
            if (ActionPoints > 0)
            {
                if (moving || targetTile == this._targetTile) return;
                moving = true;
                Debug.Log("Tile Selected");
                Debug.Log(this._targetTile);
                Debug.Log(targetTile);
                List<ITile> path = _tileGraph.GetPathToTile(this._targetTile, targetTile);

                if (path != null && path.Count > 0)
                {
                    this._targetTile = targetTile;
                }
            }
        }
    }
}
