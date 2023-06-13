using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceTemplate : ScriptableObject
{
    public Material SpaceMaterial;

    public abstract void ActivateSpaceEffect(PlayerClass AffectedPlayer);
}
