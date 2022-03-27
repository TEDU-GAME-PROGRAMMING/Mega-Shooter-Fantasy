using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWorldManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public float pickUpDistance = 5.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If the player tries to pick up anything on, it is detected by keycode E
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Physics.Raycast(this.transform.position, this.transform.forward, out hit, pickUpDistance);
            
            
            if(hit.collider != null)
            {
                Item item = new Item(hit.collider.gameObject);
                GameManager.player.GetComponent<Player>().Inventory.AddItem(item);

            }
            

        }
    }
}
