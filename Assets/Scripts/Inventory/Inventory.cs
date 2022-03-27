using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    //2D array for placing items. Indexing will be faster compared to the list structure.
    private Item[,] inventory;
    private int currentSize = 0;
    private int lastX = 0, lastY = 0;
    private int width;
    private int height;

    public Inventory(int width, int height)
    {
        this.width = width;
        this.height = height;
        inventory = new Item[width, height];


    }

    public Inventory()
    {


    }

    public void AddItem(Item item)
    {

        inventory[lastX, lastY] = item;
        lastX++;
        if (lastX > width)
        {
            lastY++;
            lastX = 0;
        }
        currentSize++;

    }

    public void AddItem(Item item, int x, int y)
    {
        if(x > width || y > height || y < 0 || x < 0 )
        {
            return;
        }
        if(inventory[x, y] == null)
        {
            currentSize++;
        }
        inventory[x, y] = item;
        

    }

    //Removed the first instance of the item found in the inventory.
    public void RemoveItem(Item item)
    {
        inventory[lastX, lastY] = null;

    }

    //Removed the instanve of the item found at the index i of the inventory;
    public void RemoveItem(Item item, int x, int y)
    {
        if (x > width || y > height || y < 0 || x < 0)
        {
            return;
        }

        if (inventory[x, y] != null)
        {
            currentSize--;
        } else
        {

        }
        inventory[x, y] = null;

    }

}
