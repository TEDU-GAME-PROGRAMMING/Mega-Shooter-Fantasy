using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    private string itemName = "";
    private int itemID;
    private float damage, durability, weight, attackSpeed;
    private int minWearingLevel = 0;
    //private AdditionalPowerUps powerUp;

    public Item()
    {

    }

    public Item(GameObject g)
    {
        itemID = -1;
        damage = 0;
    }


}

public enum ItemType
{

    Weapon,
    Material, 
    Consumable,

}