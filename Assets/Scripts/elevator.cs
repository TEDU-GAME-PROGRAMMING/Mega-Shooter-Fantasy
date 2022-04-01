using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{

    public GameObject moveplatform;
    public float timerInput = 15;

    bool isMovingUp = false;
    Vector3 origin;
    float timer;

    public void Start()
    {
        origin = moveplatform.transform.position;
        timer = timerInput;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (!isMovingUp && origin.y < moveplatform.transform.position.y && timer <= 0)
        {
            //going down
            moveplatform.transform.position -= Vector3.up * Time.deltaTime;
        }
        
        if(origin.y+ 0.3 > moveplatform.transform.position.y)
        {
            timer = timerInput;
        }
    }
    private void OnTriggerStay()
    {
        isMovingUp = true;
        moveplatform.transform.position += Vector3.up * Time.deltaTime;
        GameManager.player.transform.position += Vector3.up * Time.deltaTime;

    }
    private void OnTriggerExit()
    {
        isMovingUp = false;
    }

}
