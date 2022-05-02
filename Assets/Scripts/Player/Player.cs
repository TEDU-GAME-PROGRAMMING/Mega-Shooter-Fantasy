using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public int inventoryXSize = 5;
    public int inventoryYSize = 5;
    public float expToNextLevel = 100f;
    public float currentExp = 0f;
    public int playerLevel = 0;
    private Inventory inventory;

    public GameObject experienceDisplay;

    public Inventory Inventory { get => inventory; set => inventory = value; }

    public float totalExperience = 0f; 
    private void Awake()
    {
        inventory = new Inventory(inventoryXSize, inventoryYSize);

    }

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = (expToNextLevel + 100f) * 1.1f;
        experienceDisplay.GetComponent<Slider>().value = currentExp;
    }

    // Update is called once per frame
    void Update()
    {
        CheckExperienceBar();
    }

    public void CheckExperienceBar()
    {
        if(currentExp >= expToNextLevel)
        {
            playerLevel++;
            currentExp = 0;
            experienceDisplay.GetComponent<Slider>().value = currentExp;
            expToNextLevel = (expToNextLevel + 100f) * 1.1f;

        } 

    }
}
