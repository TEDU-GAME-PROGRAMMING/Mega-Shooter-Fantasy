using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunMovement : MonoBehaviour {


    public float moveAmount, moveSpeed, moveX, moveY;
    public GameObject t;
    public Vector3 originalPosition;
    public Vector3 newPosition;
    public WeaponSwitching weaponSwitching;
    void Start () {
        originalPosition = t.transform.localPosition;
    }

    // Update is called once per frame
    void Update () {

        moveX = Input.GetAxis("Mouse X") * Time.deltaTime * moveAmount;
               
        moveY = Input.GetAxis("Mouse Y") * Time.deltaTime * moveAmount;

        if(moveX != 0 || moveY != 0)
        {
            t = weaponSwitching.currentlySelectedGameObject;

        }


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
        newPosition = new Vector3(t.transform.localPosition.x + moveX, t.transform.localPosition.y + moveY, t.transform.localPosition.z);

        t.transform.localPosition = Vector3.Lerp(newPosition, originalPosition, moveSpeed * Time.deltaTime);

    }
}