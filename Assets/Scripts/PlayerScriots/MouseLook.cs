using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity;

    public Transform playerBody;
    private bool init = false;

    public GameObject sensitivitySlider;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //xRotation = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        mouseSensitivity = sensitivitySlider.GetComponent<Slider>().value;
        //xRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // rotation of the player with the mouse position
        if (Input.GetMouseButtonDown(0))
        {
            init = true;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        if (init)
        {
            xRotation -= mouseY;
        }
       
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localEulerAngles = new Vector3(xRotation,transform.localRotation.y,transform.localRotation.z);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
