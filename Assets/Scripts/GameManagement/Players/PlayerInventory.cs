using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public ItemTemplate CurrentWeapon;
    public ItemTemplate CurrentArmor;

    void Start()
    {
        
    }


    void Update()
    {
        CurrentWeapon = this.GetComponent<PlayerClass>().Class.Weapon;
        CurrentArmor = this.GetComponent<PlayerClass>().Class.Armor;
    }
}
