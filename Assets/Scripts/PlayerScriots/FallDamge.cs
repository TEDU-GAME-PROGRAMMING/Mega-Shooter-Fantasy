using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallDamge : MonoBehaviour
{

    PlayerMovement player = new PlayerMovement();
    public int damageThreshold = -12;
    public bool isTakeFallDamage = false;
    float fallVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //is player take damage from falling
        if(player.velocity.y < damageThreshold)
        {
            isTakeFallDamage = true;
            //save the fall velocity before landing
            fallVelocity = player.velocity.y;
        }

        //player fell the ground, and take damage after landing
        if(player.isGrounded && isTakeFallDamage)
        {
             //damage formula
             player.healthCurrent -= Mathf.Pow(fallVelocity,2) / 15f;
             isTakeFallDamage = false;
        }
    }
}
