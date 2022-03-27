using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
   // public GameObject MainMenu;
    public Slider loadingBar;
    public void LoadScene(int levelIndex)
    {
        //Get the character stats

        //Set the character stats 


        //Load the scene
        StartCoroutine(LoadSceneAsynchronously(levelIndex));

    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScreen.SetActive(true);
       // MainMenu.SetActive(false);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;


        }
    }
}
