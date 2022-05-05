using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWorldManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public float pickUpDistance = 5.0f;
    public GameObject inventoryCanvas;
    public GameObject inventoryBackground;
    // Update is called once per frame
    void Update()
    {
        //If the player tries to pick up anything on, it is detected by keycode E
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out hit, pickUpDistance);
            //Debug.DrawRay(this.transform.position, this.transform.forward);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Item>() != null )
            {
                Item itemComp = hit.collider.gameObject.GetComponent<Item>();
                switch (hit.collider.gameObject.GetComponent<Item>().type)
                {

                    case ItemType.Ammo:

                        GameManager.player.GetComponent<CharacterStats>().
                            weaponHolder.GetComponent<WeaponSwitching>().
                            currentlySelectedGameObject.GetComponent<Gun>().maxCurrentAmmo += itemComp.ammoAmount;
                        Destroy(hit.transform.gameObject);
                        break;

                    case ItemType.Weapon:
                        AddToInventory(hit);
                        
                        
                        break;

                    default:


                        break;



                }


            }


        }
    }

    public void AddToInventory(RaycastHit hit)
    {
        Item item = hit.collider.GetComponent<Item>();
        bool added = GameManager.player.GetComponent<Player>().Inventory.AddItem(item);
        if (added)
        {
            inventoryCanvas.GetComponent<InventoryUIManagement>().AddItem(hit.collider.gameObject);
            Destroy(hit.collider.gameObject);

        }

    }
}
