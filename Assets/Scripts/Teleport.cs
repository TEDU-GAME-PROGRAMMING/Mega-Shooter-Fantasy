using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Teleport : MonoBehaviour
{

    [SerializeField] Vector3 destinationA;
    [SerializeField] Vector3 destinationB;
    [SerializeField] Vector3 destinationC;


    public GameObject DestinationCanvas;
    private void Start()
    {
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
