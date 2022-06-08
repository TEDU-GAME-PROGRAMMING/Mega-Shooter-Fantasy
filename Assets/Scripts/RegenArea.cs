using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RegenArea : MonoBehaviour
{

    public float regen = 3;
    // Start is called before the first frame update



    private void OnTriggerStay(Collider other)
    {

        // Debug.Log("any object entered" + other.gameObject.name);
        if (other.gameObject.name.Equals("First Person Player"))
        {
            if(GameManager.playerStats.healthCurrent < GameManager.playerStats.healthMax)
            {
                GameManager.playerStats.healthCurrent += regen * Time.deltaTime;
            }

        }


    }


}
