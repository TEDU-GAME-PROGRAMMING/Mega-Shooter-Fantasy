using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWorldManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public float pickUpDistance = 5.0f;

    // Update is called once per frame
    void Update()
    {
        //If the player tries to pick up anything on, it is detected by keycode E
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Physics.Raycast(this.transform.position, this.transform.forward, out hit, pickUpDistance);
            
            
            if(hit.collider != null && hit.collider.gameObject.GetComponent<Item>() != null )
            {
                Debug.Log(hit.collider.name);
                Item item = new Item();
                item.AttackSpeed = 1.2f;
                item.Damage = 13.3f;
                item.Durability = 3.5f;
                item.ItemID = 3;
                item.Weight = 3.5f;
                item.ItemName = "Item";
                GameManager.player.GetComponent<Player>().Inventory.AddItem(item);

            }
            

        }
    }
}
