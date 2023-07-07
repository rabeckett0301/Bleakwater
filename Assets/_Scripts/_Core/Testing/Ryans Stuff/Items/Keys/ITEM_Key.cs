using Bleakwater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key Item", menuName = "Scriptable Objects/Items/New Key Item", order = 1)]

public class ITEM_Key : ScriptableObject, IKeyItem
{
    [SerializeField]
    private Sprite icon;

    public Sprite Icon => icon;

    public string Description;

    [TextArea]
    public string Effect;
}
