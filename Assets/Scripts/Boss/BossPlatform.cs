using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPlatform : MonoBehaviour
{
    public GameObject boss;
    public Target target;
    
    public Image bossHealth;
    public Text bossName;

    private void Awake()
    {
        //disappear ui
        bossHealth.gameObject.SetActive(false);
        bossName.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("any object entered" + other.gameObject.name);
        if (other.gameObject.name.Equals("First Person Player"))
        {
            //appear ui
            if (target.healthCureent > 0)
            {
                bossHealth.gameObject.SetActive(true);
                bossName.gameObject.SetActive(true);
            }
                
        }

    }

    private void OnTriggerStay(Collider other)
    {
        bossHealth.fillAmount = target.healthCureent / target.healthMax;
        bossName.text = boss.name;



        if (target.healthCureent <= 0)
        {
            //disappear ui
            bossHealth.gameObject.SetActive(false);
            bossName.gameObject.SetActive(false);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        
        if (other.gameObject.name.Equals("First Person Player"))
        {
            //disappear ui
            bossHealth.gameObject.SetActive(false);
            bossName.gameObject.SetActive(false);
        }
    }
}
