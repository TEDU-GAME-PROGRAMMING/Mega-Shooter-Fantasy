using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destriction : MonoBehaviour
{
    public GameObject destroyed;

    public void Destroy()
    {
        Instantiate(destroyed, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
