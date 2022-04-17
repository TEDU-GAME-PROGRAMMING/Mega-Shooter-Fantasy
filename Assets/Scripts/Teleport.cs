using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] Vector3 destination;


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Equals("First Person Player"))
        {
            GameManager.player.transform.position = destination;
        }
       
    }


}
