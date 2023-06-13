using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Space", menuName = "Spaces/Blank Space", order = 1)]

public class SE_DoNothing : SpaceTemplate
{
    public override void ActivateSpaceEffect(PlayerClass AffectedPlayer)
    {
        Debug.Log("Doing nothing");
    }
}
