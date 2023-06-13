using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/New Item", order = 1)]

public class ItemTemplate : ScriptableObject
{
    public ItemType Type;
    public string Name;
    public string Description;
    public string Value;
}
