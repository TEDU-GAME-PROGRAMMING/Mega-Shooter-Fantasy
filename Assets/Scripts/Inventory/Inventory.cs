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

    public void AddItem(Item item)
    {
        if(CurrentSize < Width * Height)
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

}
