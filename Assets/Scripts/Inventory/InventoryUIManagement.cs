using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventoryUIManagement : MonoBehaviour, IPointerDownHandler
{
    public int clickedInventoryX = 0;
    public int clickedInventoryY = 0;
    private Inventory inventory;
    private bool inventoryOpen = true;
    public float paddingX = 20f, paddingY = 20f;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Each click calculate the x and y position corresponding to the inventory ui.
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO: DO NOT FORGET TO REPLACE THE INVENTORY INSTANCE TO THE CREATED ONE IN PLAYER SCRIPT
        inventory = new Inventory(5, 5);
    
    }

    // Update is called once per frame
    void Update()
    {
        if(inventoryOpen || Input.GetMouseButtonDown(0))
        {
            Vector3 clickedPos = Input.mousePosition;



        }
    }

    //Get the index of the clicked object.
    public int[] CalculateIndices()
    {
        int[] indices = new int[2];

        //return the indices array as x -> [0] and y -> [1]



        return indices;

    }

}
