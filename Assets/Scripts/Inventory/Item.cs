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
        ItemID = -1;
        Damage = 0;
    }

    public string ItemName { get => itemName; set => itemName = value; }
    public int ItemID { get => itemID; set => itemID = value; }
    public float Damage { get => damage; set => damage = value; }
    public float Durability { get => durability; set => durability = value; }
    public float Weight { get => weight; set => weight = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public int MinWearingLevel { get => minWearingLevel; set => minWearingLevel = value; }
}

public enum ItemType
{

    Weapon,
    Material, 
    Consumable,

}