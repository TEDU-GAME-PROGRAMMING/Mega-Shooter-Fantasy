using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    public float healthMax = 50f;
    public float healthCureent;
    public float onDeathExperienceGiven = 100f;
    int counter = 0;

    public int targetLevel = 0;
    public string targetName = "DefaultNPCName";


    private void Start()
    {
        healthCureent = healthMax;
    }

    public void TakeDamage(float amount)
    {
        healthCureent -= amount;

        if (healthCureent <= 0f )
        {
            counter++;
            
            Die();

           
        }

    }


    public void Die()
    {
        if (this.GetComponent<Animator>() !=null)
        {
            this.GetComponent<Animator>().Play("Die");
        }
        
        if (counter == 1)
        {
            GameManager.player.GetComponent<Player>().totalExperience += onDeathExperienceGiven;
            GameManager.player.GetComponent<Player>().currentExp += onDeathExperienceGiven;
            GameManager.player.GetComponent<Player>().CheckExperienceBar();
            GameManager.player.GetComponent<Player>().experienceDisplay.GetComponent<Slider>().value = GameManager.player.GetComponent<Player>().currentExp / GameManager.player.GetComponent<Player>().expToNextLevel;

        }
       // Destroy(gameObject, 1.5f);
        if (this.GetComponent<EnemyBehaviour>() != null)
        {
            Destroy(this.GetComponent<EnemyBehaviour>());
            Destroy(gameObject, 2f);
        }
        if (this.GetComponent<EnemyNavMesh>() != null)
        {
            Destroy(this.GetComponent<EnemyNavMesh>());
            Destroy(gameObject);
        }
        if (this.GetComponent<BossNavMesh>() != null)
        {
            Destroy(this.GetComponent<BossNavMesh>());
            Destroy(gameObject,2f);
        }








    }


}
