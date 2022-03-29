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
    public bool inventoryOpen = true;
    public float paddingX = 20f, paddingY = 20f;

    public int inventoryXSize = 0;
    public int inventoryYSize = 0;


    public GraphicRaycaster graphicRaycaster;

    public EventSystem eventSystem;
    public PointerEventData pointerEventData;

    public GameObject inventoryBackground;

    public GameObject inventoryGrid;

    public GameObject selectedObject;

    public bool isSelected = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        //Each click calculate the x and y position corresponding to the inventory ui.
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO: DO NOT FORGET TO REPLACE THE INVENTORY INSTANCE TO THE CREATED ONE IN PLAYER SCRIPT
        inventory = new Inventory(inventoryXSize, inventoryYSize);

        for(int y = 0; y < inventory.Width; y++)
        {
            for (int x = 0; x < inventory.Width; x++)
            {
                //inventory.InventoryArray[x, y] = new Item();
            }
        }

        if (!inventoryOpen)
        {
            inventoryBackground.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {

            inventoryOpen = !inventoryOpen;
            inventoryBackground.SetActive(inventoryOpen);

        }

        if (inventoryOpen)
        {
            List<RaycastResult> results = new List<RaycastResult>();

            pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;
            graphicRaycaster.Raycast(pointerEventData, results);

            /*            
                On left click, either select and move the item or 
                deselect it and place it to the corresponding inventory slot

            */
            if (Input.GetMouseButtonDown(0))
            {
                if(isSelected)
                {



                } else
                {
                    selectedObject = results[0].gameObject;

                }


            }
            if(isSelected)
                selectedObject.transform.position = Input.mousePosition;

            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
            }

        }

    }

    public void DisplayStatsOnHover()
    {

    }

    //Get the index of the clicked object.
    public int[] CalculateIndices()
    {
        int[] indices = new int[2];

        //return the indices array as x -> [0] and y -> [1]



        return indices;

    }

}
