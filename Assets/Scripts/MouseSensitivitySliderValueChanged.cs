using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MouseSensitivitySliderValueChanged : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().value = Camera.main.GetComponent<MouseLook>().mouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseSensitivitySet()
    {
        Camera.main.GetComponent<MouseLook>().mouseSensitivity = this.GetComponent<Slider>().value;
    }
}
