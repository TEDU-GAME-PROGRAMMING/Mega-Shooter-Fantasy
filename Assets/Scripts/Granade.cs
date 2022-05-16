using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    public GameObject exlosionEffect;
    GameObject x;
    //private ParticleSystem system;

    private float countdown;
    bool hasExploded = false;
    public float destroyTimer;

    public int damageOfEnemy = 50;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        destroyTimer = exlosionEffect.GetComponent<ParticleSystem>().main.duration;
    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }

        if (hasExploded)
        {
            destroyTimer -= Time.deltaTime;
        }
            

        if (destroyTimer <= 0)
        {
            Destroy(x);
            Destroy(gameObject);
        }

    }
    void Explode()
    {
       x = Instantiate(exlosionEffect, transform.position,transform.rotation);
        // Debug.Log("ufuk patladý");
       Collider[] collidersDest =  Physics.OverlapSphere(transform.position, radius );

        foreach (Collider nearbyObject in collidersDest)
        {
            
            Destriction destriction = nearbyObject.GetComponent<Destriction>();
            if(destriction != null)
            {
                destriction.Destroy();
            }

        }
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
    // TODO we have to add the explosion radius in order to trigger the explosion event
    /*private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //Debug.Log("damage verdi");
            CharacterStats.instance.TakeDamage(damageOfEnemy);
        }
        else
        {

        }
        // Debug.Log(other.gameObject.name);
        Destroy(gameObject, 1f);
    }*/

}
