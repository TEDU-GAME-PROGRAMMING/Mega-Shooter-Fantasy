using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{

    
    public int inventoryXSize = 5;
    public int inventoryYSize = 5;
    public float expToNextLevel = 100f;
    public float currentExp = 0f;
    public int playerLevel = 0;
    private Inventory inventory;
    public string levelString = "Level";
    public int remaingSkillPoints = 0;
    //public int levelValue = 0;
    public GameObject remaingSkillPointText;
   
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
        //CheckExperienceBar();
    }

    public void CheckExperienceBar()
    {
        if(currentExp >= expToNextLevel)
        {
            while (!(currentExp < expToNextLevel))
            {
                playerLevel++;
                remaingSkillPoints++;
                currentExp = currentExp - expToNextLevel;
                experienceDisplay.GetComponent<Slider>().value = currentExp;
                expToNextLevel = (expToNextLevel + 100f) * 1.1f;
                
            }
            experienceDisplay.transform.Find(levelString).Find("LevelText").GetComponent<TMP_Text>().text = playerLevel.ToString();
            remaingSkillPointText.GetComponent<TMP_Text>().text = remaingSkillPoints.ToString();
        } 

    }
}
