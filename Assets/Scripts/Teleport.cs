using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] Vector3 destination;

    private void OnTriggerEnter()
    {
        GameManager.player.transform.position = destination;
    }


}
