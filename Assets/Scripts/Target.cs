using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float healthMax = 50f;
    public float healthCureent;

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
        Destroy(this.GetComponent<EnemyBehaviour>());
        Destroy(gameObject, 2f);
    }


}
