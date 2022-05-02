using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    public float healthMax = 50f;
    public float healthCureent;
    public float onDeathExperienceGiven = 100f;

    private void Start()
    {
        healthCureent = healthMax;
    }

    public void TakeDamage(float amount)
    {
        healthCureent -= amount;

        if (healthCureent <= 0f )
        {

            Die();
        }

    }


    public void Die()
    {

        this.GetComponent<Animator>().Play("Die");
        GameManager.player.GetComponent<Player>().totalExperience += onDeathExperienceGiven;
        GameManager.player.GetComponent<Player>().currentExp += onDeathExperienceGiven;
        GameManager.player.GetComponent<Player>().experienceDisplay.GetComponent<Slider>().value = GameManager.player.GetComponent<Player>().currentExp / GameManager.player.GetComponent<Player>().expToNextLevel;

        Destroy(this.GetComponent<EnemyBehaviour>());



        Destroy(gameObject);



    }


}
