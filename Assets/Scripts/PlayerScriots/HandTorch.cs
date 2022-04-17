using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTorch : MonoBehaviour
{
    public Light torch;
    // Start is called before the first frame update
    bool isTorchOn = false;
    public int brigthness = 5;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            isTorchOn = !isTorchOn;
        }

        if (isTorchOn)
        {
            torch.intensity = brigthness;
        }
        else
        {
            torch.intensity = 0;
        }
        
    }
}
