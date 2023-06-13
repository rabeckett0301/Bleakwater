using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Class", menuName = "Scriptable Objects/New Player Class", order = 1)]

public class PlayerTemplate : ScriptableObject
{
    public PlayerClassType Name;
    public string Description;

    public int BaseHealth;

    public int BaseStrength;
    public int BaseAgility;
    public int BaseMindfulness;
    public int BaseDarkness;
    public int BaseFocus;

    public ItemTemplate Weapon;
    public ItemTemplate Armor;
}
