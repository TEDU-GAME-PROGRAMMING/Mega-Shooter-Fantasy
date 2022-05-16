using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OnDeadSceneManagment : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
