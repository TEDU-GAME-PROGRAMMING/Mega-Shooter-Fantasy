using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatScreen : MonoBehaviour
{
    public GameObject CharacterStatsCanvas;
    public string CharacterStats = "CharacterStats";
    public bool display = false;
    // Start is called before the first frame update
    void Start()
    {
        if (CharacterStatsCanvas == null)
        {
            CharacterStatsCanvas = GameObject.Find(CharacterStats);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            display = !display;
            if (display == true)
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
            CharacterStatsCanvas.SetActive(display);
        }
    }
}
