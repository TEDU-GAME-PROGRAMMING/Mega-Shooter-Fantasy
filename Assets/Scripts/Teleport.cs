using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Teleport : MonoBehaviour
{

    private Vector3 destinationA;
    private Vector3 destinationB;
    private Vector3 destinationC;

    public GameObject firstPosition;
    public GameObject secondPosition;
    public GameObject thirdPosition;


    public GameObject DestinationCanvas;
    private void Start()
    {
        // the destionation is set to the game object.
        destinationA.x = firstPosition.transform.position.x;
        destinationA.y = firstPosition.transform.position.y;
        destinationA.z = firstPosition.transform.position.z;
        // second destionation.
        destinationB.x = secondPosition.transform.position.x;
        destinationB.y = secondPosition.transform.position.y;
        destinationB.z = secondPosition.transform.position.z;
        // third destination.
        destinationC.x = thirdPosition.transform.position.x;
        destinationC.y = thirdPosition.transform.position.y;
        destinationC.z = thirdPosition.transform.position.z;
        


        DestinationCanvas.SetActive(false);
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Equals("First Person Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            DestinationCanvas.SetActive(true);
        }
       
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name.Equals("First Person Player"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            DestinationCanvas.SetActive(false);
        }
        

    }
    public void DestinationA()
    {
            GameManager.player.transform.position = destinationA;
        
    }
    public void DestinationB()
    {
        GameManager.player.transform.position = destinationB;

    }
    public void DestinationC()
    {
        GameManager.player.transform.position = destinationC;

    }


}
