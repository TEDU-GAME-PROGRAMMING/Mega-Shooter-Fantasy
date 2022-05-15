using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectiveUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textArea;
    public GameObject objectiveGameObject;
    public bool objectiveOpen = true;

    void Start()
    {
        if (!objectiveOpen)
        {
            objectiveGameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            objectiveOpen = !objectiveOpen;
            objectiveGameObject.SetActive(objectiveOpen);
            if (objectiveOpen == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0.0f;

            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1.0f;
            }

        }

    }

    public void OnChange()
    {
        //textArea.GetComponent<TMPro_Text>();
    }
}
