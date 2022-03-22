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
            settingsCanvas.SetActive(display);
        }

    }

}
