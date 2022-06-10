using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public AudioSource[] shootingSound;
    bool a = true;
    //public AudioSource ReloadingSound;
    private void Start()
    {
        shootingSound = GetComponents<AudioSource>();

    }

    private void OnTriggerEnter()
    {
        if(a == true)
        {
            shootingSound[0].PlayOneShot(shootingSound[0].clip);
            a = false;  
        }
    }

    private void OnTriggerExit()
    {

        
    }

}
