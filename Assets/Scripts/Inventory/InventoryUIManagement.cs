using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using TMPro;
public class InventoryUIManagement : MonoBehaviour, IPointerDownHandler
{

    /*
    TODO

        Invetory and Options menu both set the time scale but only game manager should do it to 
        prevent conflicts between ui elements 


    Add inventory text on top of the inventory

    �nventory item name displayed below

     Same items should stack

     Check if item type is weapon, add to weapon holder



     */

    public int clickedInventoryX = 0;
    public int clickedInventoryY = 0;
    private Inventory inventory;
    public bool inventoryOpen = true;
    public float paddingX = 20f, paddingY = 20f;


    public GraphicRaycaster graphicRaycaster;

    public EventSystem eventSystem;
    public PointerEventData pointerEventData;

    public GameObject inventoryBackground;

    public GameObject inventoryGrid;

    public GameObject selectedObject;

    public GameObject[,] inventoryUIArray;
    public Item[,] inventoryItemArray;

    public bool isSelected = false;
    public bool changeName = false;

    GameObject selectedNew;
    GameObject selectedOldObjectParent;
    string previouslySelectedName;
    string newlySelectedName;
    GameObject previousItemText;
    GameObject newItemText;

    GameObject wearingGameObject;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Each click calculate the x and y position corresponding to the inventory ui.
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }

    // Start is called before the first frame update
    void Start()
    {
        //TODO: DO NOT FORGET TO REPLACE THE INVENTORY INSTANCE TO THE CREATED ONE IN PLAYER SCRIPT
        inventory = GameManager.player.GetComponent<Player>().Inventory;
        inventoryUIArray = new GameObject[inventory.Width, inventory.Height];
        for (int y = 0; y < inventory.Width; y++)
        {
            for (int x = 0; x < inventory.Height; x++)
            {
                GameObject instantiatedItemSlot = Instantiate(inventoryGrid, this.transform);

                instantiatedItemSlot.name = instantiatedItemSlot.name + x +" " + y;
                instantiatedItemSlot.GetComponent<RectTransform>().pivot = new Vector2(0f, 1f);
                instantiatedItemSlot.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
                instantiatedItemSlot.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
                instantiatedItemSlot.GetComponent<RectTransform>().anchoredPosition = new Vector3(x * (instantiatedItemSlot.GetComponent<RectTransform>().rect.width + paddingX),
                                                           -y * (instantiatedItemSlot.GetComponent<RectTransform>().rect.height + paddingY),
                                                           0
                                                            );
                instantiatedItemSlot.transform.parent = inventoryBackground.transform;
                instantiatedItemSlot.transform.Find("ItemName").GetComponent<TMP_Text>().raycastTarget = false;

                inventoryUIArray[x, y] = instantiatedItemSlot;
                //inventory.InventoryArray[x, y] = new Item();

                //instantiatedItemSlot.GetComponent<RectTransform>().sizeDelta = size;

                //instantiatedItemSlot.transform.parent = canvas.transform;
                //instantiatedItemSlot.transform.position = new Vector3(a * buttonWidth + offsetX / 2, i * buttonHeight + offsetY / 2);
                //inventoryGridArray[a, i] = gu.gameObject;

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
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        stopwatch.Start();
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryOpen = !inventoryOpen;
            inventoryBackground.SetActive(inventoryOpen);
            if (inventoryOpen == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0.0f;
                
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1.0f;
            }

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
                Debug.Log("Click test " + changeName);

                if (results.Any())
                {

                    //If the mouse clicked at pos brought a inventory grid, check if the mouse currently selects any obj
                    if (isSelected)
                    {

                        Swap(results);

                        //If the selectedNew object is equal to wearing, update player stats with . 
                        if(selectedNew.transform.parent == wearingGameObject)
                        {

                        }

                        //Update the inventory item slot lastX, lastY for the switched item
                        //and switch the inventory 
/*                        int x1, y1, x2, y2;
                        result.gameObject.name;
                        inventory.SwitchSlots(x1, y1, x2, y2);
*/
                    }
                    else
                    {

                        selectedObject = results[0].gameObject;
                        previouslySelectedName = selectedObject.transform.parent.Find("ItemName").GetComponent<TMP_Text>().text;
                        previousItemText = selectedObject.transform.parent.Find("ItemName").gameObject;

                        //Debug.Log("selectedOld assigned " + selectedObject.transform.parent.Find("ItemName").GetComponent<TMP_Text>().text);

                        isSelected = true;

                        //For detecting the objects below the selected obj.
                        selectedObject.GetComponent<Image>().raycastTarget = false;

                    }

                }
                else
                {
                    if(selectedObject != null)
                    {
                        isSelected = false;
                        if (changeName)
                        {
                            changeName = !changeName;
                            previousItemText.GetComponent<TMP_Text>().text = newlySelectedName;
                            newItemText.GetComponent<TMP_Text>().text = previouslySelectedName;


                        }

                        selectedObject.GetComponent<Image>().raycastTarget = true;

                        //selectedObject.transform.localPosition = Vector3.zero;
                        selectedObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;


                    }

                }



            }
            if(isSelected)
            {
                selectedObject.transform.position = Input.mousePosition;
                if(results.Any())
                {
                }


            }

            /*            foreach (RaycastResult result in results)
                        {
                            Debug.Log("Hit " + result.gameObject.name);
                        }*/

        }

        stopwatch.Stop();
        double ticks = stopwatch.ElapsedTicks;
        double seconds = ticks / System.Diagnostics.Stopwatch.Frequency;
        double milliseconds = (ticks / System.Diagnostics.Stopwatch.Frequency) * 1000;
        //Debug.Log(string.Format("MyMethod took {0} ms to complete", milliseconds));

    }

    public void AddItem(GameObject pickedObject)
    {
        //Debug.Log("before " + inventory.LastX + "  " + inventory.LastY);
        //iki tane add yapinca lastx lasty baska yerde degisiyor bug. simdilik 0 0 
        Item pickedItem = pickedObject.GetComponent<Item>();

        Item item = new Item();
        Debug.Log("before " + inventory.LastX + "  " + inventory.LastY);
        item = inventoryUIArray[inventory.LastX == 0 ? inventory.LastX : inventory.LastX - 1, inventory.LastY].transform.Find("Item").gameObject.AddComponent<Item>();
        inventory.CopyItem(item, pickedItem);

        Debug.Log("AFTER " + inventory.LastX + "  " + inventory.LastY);
        inventory.LastX--;
        inventoryUIArray[inventory.LastX, inventory.LastY].transform.Find("Item").GetComponent<Image>().sprite = pickedObject.GetComponent<Item>().itemImage;
        inventoryUIArray[inventory.LastX, inventory.LastY].transform.Find("ItemName").GetComponent<TMP_Text>().text = pickedItem.itemName;
        inventory.LastX++;
        //(inventory.LastX)++;
        //inventoryItemArray[0, 0] = item;
        //inventoryUIArray[inventory.LastX, inventory.LastY].gameObject.AddComponent(typeof(SphereCollider));
    }

    public void Swap(List<RaycastResult> results)
    {

        changeName = !changeName;

        //If isSelected, then another item is being dragged,
        //so switch them 
        selectedNew = results[0].gameObject;
        selectedOldObjectParent = selectedObject.transform.parent.gameObject;
        newlySelectedName = selectedNew.transform.parent.Find("ItemName").GetComponent<TMP_Text>().text;

        previousItemText = selectedOldObjectParent.transform.Find("ItemName").gameObject;
        newItemText = selectedNew.transform.parent.Find("ItemName").gameObject;

        selectedObject.transform.parent = selectedNew.transform;
        selectedObject.transform.localPosition = Vector3.zero;
        selectedObject.transform.parent = selectedNew.transform.parent;
        //selectedObject.GetComponent<RectTransform>().x 



        selectedNew.transform.parent = selectedOldObjectParent.transform;


        selectedObject.GetComponent<Image>().raycastTarget = true;
        selectedNew.GetComponent<Image>().raycastTarget = false;

        //selectedNew.GetComponent<Image>().sprite = selectedObject.GetComponent<Image>().sprite;
        //selectedObject.GetComponent<Image>().color = Color.red;


        selectedObject = selectedNew;

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
