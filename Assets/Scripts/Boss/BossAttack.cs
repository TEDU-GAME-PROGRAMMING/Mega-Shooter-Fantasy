using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision");
        if (collision.gameObject.name.Equals("Cylinder"))
        {
            //Debug.Log("Hitted");
            GameManager.playerStats.healthCurrent -= 20;
        }
    }
}
