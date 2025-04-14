using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainLevel()
    {
        SceneManager.LoadScene("Levels");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // For editor testing
    }

    public void LoadBloomingFlowerScene()
    {
        SceneManager.LoadScene("BloomingFlower"); // make sure the name matches your scene name!
    }
}
