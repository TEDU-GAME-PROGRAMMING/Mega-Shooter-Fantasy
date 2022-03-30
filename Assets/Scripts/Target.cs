using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f )
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
