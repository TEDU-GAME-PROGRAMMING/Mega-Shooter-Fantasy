using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int inventoryXSize = 5;
    public int inventoryYSize = 5;

    private Inventory inventory;

    public Inventory Inventory { get => inventory; set => inventory = value; }


    private void Awake()
    {
        inventory = new Inventory(inventoryXSize, inventoryYSize);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
