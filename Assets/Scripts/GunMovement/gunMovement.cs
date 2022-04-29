using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunMovement : MonoBehaviour {


    public float moveAmount, moveSpeed, moveX, moveY;
    public GameObject t;
    public Vector3 originalPosition;
    public Vector3 newPosition;
    void Start () {
        originalPosition = t.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate () {

        moveX = Input.GetAxis("Mouse X") * Time.deltaTime * moveAmount;
               
        moveY = Input.GetAxis("Mouse Y") * Time.deltaTime * moveAmount;

        /*        if(Vector3.Distance(originalPosition, newPosition) < 0.051f)
                {
                    Debug.Log("Insdde");

                    newPosition = new Vector3(t.transform.localPosition.x + moveX, t.transform.localPosition.y + moveY, t.transform.localPosition.z);
                    t.transform.localPosition = Vector3.Lerp(t.transform.localPosition, newPosition, moveSpeed * Time.deltaTime);

                } else
                {
                    transform.localPosition = Vector3.Lerp(t.transform.localPosition, originalPosition, moveSpeed * Time.deltaTime);
                    newPosition = transform.localPosition;

                }
                if (Input.GetKey(KeyCode.H))
                {
                    t.transform.localPosition = originalPosition;
                }*/
        Vector3 f = new Vector3(moveX, moveY, 0);
        transform.localPosition = Vector3.Lerp(t.transform.localPosition, f + originalPosition, moveSpeed * Time.deltaTime);
    }
}