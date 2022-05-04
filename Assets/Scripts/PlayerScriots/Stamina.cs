using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement player;
    public float staminaPower = 50;   
    public float staminaMaxDuration = 5;
    public float staminaCurrentDuration = 5;
    public Image staminaImage;
    public float OriginalSpeed ;
    public float tiredTime = 2.5f;
    private float executedLastTime = 0f;
    void Start()
    {
        player = GameManager.playerStats.GetComponent<PlayerMovement>();
        OriginalSpeed = GameManager.playerStats.speed;
        //Debug.Log(OriginalSpeed);

        staminaPower += OriginalSpeed;


    }

    // Update is called once per frame
    void Update()
    {

        UpdateUI();
        //Debug.Log("Player speed" + player.speed + " " + staminaCurrentDuration);
        //stamina
        
        if (Input.GetKey(KeyCode.LeftShift) && staminaCurrentDuration > 0)
        {
            staminaCurrentDuration -= Time.deltaTime;
            player.speed = staminaPower;
        }
        else
        {

            player.speed = OriginalSpeed;
           // Debug.Log(OriginalSpeed);
            //stamina charge
            if (staminaCurrentDuration < staminaMaxDuration)
            {
                staminaCurrentDuration += 1.5f * Time.deltaTime;
            }


        }

    }

    public void UpdateUI()
    {
        staminaImage.fillAmount = staminaCurrentDuration / staminaMaxDuration;

    }
}
