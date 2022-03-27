using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsInGame : MonoBehaviour
{
    public GameObject settingsCanvas;
    public string settingCanvasName = "SettingsCanvas";
    public bool display = false;
    // Start is called before the first frame update
    void Start()
    {
        if(settingsCanvas == null)
        {
            settingsCanvas = GameObject.Find(settingCanvasName);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            display = !display;
            if(display == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0.0f;
            } else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1.0f;
            }
            settingsCanvas.SetActive(display);
        }

    }

}
