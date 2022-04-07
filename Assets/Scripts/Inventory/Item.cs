using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    public string itemName = "";
    public int itemID;
    public float damage, durability, weight, attackSpeed;
    public int minWearingLevel = 0;
    //private AdditionalPowerUps powerUp;

    public Sprite itemImage;


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