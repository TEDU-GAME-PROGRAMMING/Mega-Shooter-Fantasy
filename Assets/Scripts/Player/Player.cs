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


    public LayerMask layerMask;

    RaycastHit hit;

    public GameObject healthBar, levelDisplay, enemyName;
    public GameObject enemy;
    public GameObject enemyWordStatsDisplay;

    private bool enemyUIVisible = false;
    

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
        UpdateTargetedEnemyUI();
    }

    private void UpdateTargetedEnemyUI()
    {
        //TODO: Add range to raycast. 100f -> range
/*        bool detected = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f, layerMask);
        if (detected != previousDetected)
        {
            enemyUIVisible = !enemyUIVisible;
        }
        previousDetected = detected;        
        //Debug.Log("Detected "  + detected +" Collider " +  hit.collider.name);
        if (enemyUIVisible)
        {
            enemyWordStatsDisplay.SetActive(enemyUIVisible);

            Target t = hit.collider.GetComponent<Target>();
            healthBar.GetComponent<Slider>().value = t.healthCureent / t.healthMax;
            levelDisplay.GetComponent<TMP_Text>().text = t.targetLevel.ToString();
            enemyName.GetComponent<TMP_Text>().text = t.targetName.ToString();



        } 
*/    

        //TODO: Needs optimization.
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f, layerMask))
        {
            enemyUIVisible = true;
            enemyWordStatsDisplay.SetActive(enemyUIVisible);

            Target t = hit.collider.GetComponent<Target>();
            healthBar.GetComponent<Slider>().value = t.healthCureent / t.healthMax;
            levelDisplay.GetComponent<TMP_Text>().text = t.targetLevel.ToString();
            enemyName.GetComponent<TMP_Text>().text = t.targetName.ToString();


        } else
        {
            enemyUIVisible = false;
            enemyWordStatsDisplay.SetActive(false);

        }

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
