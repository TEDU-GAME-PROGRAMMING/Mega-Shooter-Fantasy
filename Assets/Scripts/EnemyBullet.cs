using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private Vector3 direction;
    public int damageOfEnemy;
    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerMovement.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("damage verdi");
            CharacterStats.instance.TakeDamage(damageOfEnemy);
        }
        Destroy(gameObject,1f);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
