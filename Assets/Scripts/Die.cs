using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Die : MonoBehaviour
{
  
    void Update()
    {
         if (GameManager.playerStats.healthCurrent <= 0)
         {
            // Dying();
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("OnDeadScene");
            
        }
    }
    public void Dying()
    {
        Destroy(gameObject);
    }
}
