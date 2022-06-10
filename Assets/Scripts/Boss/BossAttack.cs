using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{

    [SerializeField] int Damage = 20;
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("First Person Player"))
        {
            //Debug.Log("Hitted");
            //GameManager.playerStats.healthCurrent -= Damage;
            CharacterStats.instance.TakeDamage(Damage);

        }
    }
}
