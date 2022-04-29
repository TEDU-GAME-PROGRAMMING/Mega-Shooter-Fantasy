using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    //2D array for placing items. Indexing will be faster compared to the list structure.
    private Item[,] inventoryArray;
    private int currentSize = 0;
    private int lastX = 0, lastY = 0;
    
    private int width;
    private int height;

    public Item[,] InventoryArray { get => inventoryArray; set => inventoryArray = value; }
    public int CurrentSize { get => currentSize; set => currentSize = value; }
    public int LastX { get => lastX; set => lastX = value; }
    public int LastY { get => lastY; set => lastY = value; }
    public int Width { get => width; set => width = value; }
    public int Height { get => height; set => height = value; }

    public Inventory(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        inventoryArray = new Item[width, height];


    }

    public Inventory()
    {


    }

    public bool CopyItem(Item item1, Item item2)
    {
        //LOOK AT HERE WHEN AN COPY ERROR OCCURS
        if (item1 == null || item2 == null)
            return false;

        item2.AttackSpeed = item1.AttackSpeed;
        item2.Damage = item1.Damage;
        item2.Durability = item1.Durability;
        item2.ItemID = item1.ItemID;
        item2.Weight = item1.Weight;
        item2.ItemName = item1.ItemName;
        item2.itemImage = item1.itemImage;

        return true;
    }

    public bool AddItem(Item item)
    {
        /*        if(CurrentSize < Width * Height)
                {
                    if (LastX >= Width)
                    {
                        LastY++;
                        LastX = 0;
                    }
                    if (LastY >= Height)
                    {
                        LastY = 0;
                    }
                    CurrentSize++;

                    Debug.Log("Added at " + lastX + " " + lastY +"| current " + CurrentSize );
                    inventoryArray[LastX, LastY] = item;
                    LastX++;
                    return true;

                } else
                {
                    return false;
                }
        */

        if (CurrentSize < Width * Height)
        {
            if (LastX >= Width)
            {
                LastY++;
                LastX = 0;
            }
            if (LastY >= Height)
            {
                LastY = 0;
            }
            CurrentSize++;

            Debug.Log("Added at " + lastX + " " + lastY + "| current " + CurrentSize);
            inventoryArray[LastX, LastY] = item;
            LastX++;
            return true;

        }
        else
        {
            return false;
        }

    }

    public void AddItem(Item item, int x, int y)
    {
        if(x > Width || y > Height || y < 0 || x < 0 )
        {
            return;
        }
        if(inventoryArray[x, y] == null)
        {
            CurrentSize++;
        }
        inventoryArray[x, y] = item;
        

    }

    //Removed the first instance of the item found in the inventory.
    public void RemoveItem(Item item)
    {
        inventoryArray[LastX, LastY] = null;

    }

    //Removed the instanve of the item found at the index i of the inventory;
    public void RemoveItem(Item item, int x, int y)
    {
        if (x > Width || y > Height || y < 0 || x < 0)
        {
            return;
        }

        if (inventoryArray[x, y] != null)
        {
            CurrentSize--;
        } else
        {

        }
        inventoryArray[x, y] = null;

    }

    public void SwitchSlots(int x1, int y1, int x2, int y2)
    {

    }

    public Item FindItem(Item item)
    {

        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                if(inventoryArray[x,y] == item)
                {
                    return inventoryArray[x,y];
                }
            }
        }
        return null;
    }

}
