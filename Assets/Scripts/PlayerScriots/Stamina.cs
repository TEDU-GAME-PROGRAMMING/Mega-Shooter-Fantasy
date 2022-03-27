using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement player = new PlayerMovement();
    public float staminaPower = 50;   
    public float staminaMaxDuration = 5;
    public float staminaCurrentDuration = 5;
    public Image staminaImage;


    void Start()
    {
        player = GameManager.player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();

        //stamina
        if (Input.GetKey(KeyCode.LeftShift) && staminaCurrentDuration > 0)
        {
            staminaCurrentDuration -= Time.deltaTime;
            player.speed = staminaPower;
        }
        else
        {

            player.speed = 12;
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
