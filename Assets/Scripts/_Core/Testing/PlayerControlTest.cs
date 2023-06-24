using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public class PlayerControlTest : PlayerPawnController
    {
        [SerializeField]
        GameObject controlTarget;
        ICharacter targetPawn;
        [SerializeField]
        GameObject targetBoardManager;
        IGameMap boardManager;
        // Start is called before the first frame update
        void Start()
        {
            boardManager = targetBoardManager.GetComponent<GameMap>();
            targetPawn = controlTarget.GetComponent<ICharacter>();
            defaultControlTarget = currentControlTarget = controlTarget.GetComponent<IControlTarget>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray selectRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(
                    selectRay, 
                    out RaycastHit hit, 
                    float.PositiveInfinity, 
                    1 << LayerMask.NameToLayer("Tile")))
                {
                    //boardManager.GetCharacterTracker().MovePawn(targetPawn, hit.collider.GetComponent<ITile>());
                    currentControlTarget.Move(hit.collider.GetComponent<ITile>());

                }
                
            }
            if (Input.GetMouseButtonDown(1))
            {
                Ray selectRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(
                    selectRay,
                    out RaycastHit hit,
                    float.PositiveInfinity,
                    1 << LayerMask.NameToLayer("Tile")))
                {
                    boardManager.GetCharacterTracker().MovePawn(targetPawn, hit.collider.GetComponent<ITile>());
                    //currentControlTarget.Move(hit.collider.GetComponent<ITile>());

                }

            }
        }
    }
}