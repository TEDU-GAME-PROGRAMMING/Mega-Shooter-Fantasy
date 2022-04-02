using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
  
    void Update()
    {
         if (GameManager.playerStats.healthCurrent <= 0)
         {
            Dying();
         }
    }
    public void Dying()
    {
        Destroy(gameObject);
    }
}
