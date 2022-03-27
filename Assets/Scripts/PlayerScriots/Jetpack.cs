using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour
{
   
    PlayerMovement player = new PlayerMovement();
    public float jetpackPower = 0;   //max 2
    public float jetpackMaxDuration = 5;
    public float jetpackCurrentDuration = 5;
    public Image FuelImage;


     void Start()
     {
        player = GameManager.player.GetComponent<PlayerMovement>();
     }

    // Update is called once per frame
    void Update()
    { 
        UpdateUI();

        //jetpack
        if (Input.GetKey(KeyCode.J) && jetpackCurrentDuration > 0)
        {
            jetpackCurrentDuration -= Time.deltaTime;
            player.velocity.y += Mathf.Sqrt((1f + jetpackPower) * Time.deltaTime);
        }


        if (player.isGrounded)
        {

            //jetpack charge
            if (jetpackCurrentDuration < jetpackMaxDuration)
            {
                jetpackCurrentDuration += 1.5f * Time.deltaTime;
            }
        }
    }

    public void UpdateUI()
    {
        FuelImage.fillAmount = jetpackCurrentDuration / jetpackMaxDuration;

    }

}
