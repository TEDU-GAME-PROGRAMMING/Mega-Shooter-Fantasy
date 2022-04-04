using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    public AudioSource[] shootingSound;
    //public AudioSource ReloadingSound;
    private void Start()
    {
        shootingSound = GetComponents<AudioSource>();

    }

    private void OnTriggerEnter()
    {
        shootingSound[0].PlayOneShot(shootingSound[0].clip);
    }

    private void OnTriggerExit()
    {

        
    }

}
