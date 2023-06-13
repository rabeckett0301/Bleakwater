using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Space", menuName = "Spaces/Subtract Action Point", order = 1)]

public class SE_TakeAP : SpaceTemplate
{
    public override void ActivateSpaceEffect(PlayerClass AffectedPlayer)
    {
        AffectedPlayer.ActionPoints -= 1;
    }
}
