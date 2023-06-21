using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public class PlayerControlTest : PlayerPawnController
    {
        [SerializeField]
        GameObject controlTarget;
        // Start is called before the first frame update
        void Start()
        {
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
                    currentControlTarget.Move(hit.collider.GetComponent<ITile>());

                }
                
            }
        }
    }
}