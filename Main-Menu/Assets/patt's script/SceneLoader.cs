using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("BloomingFlower"); 
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // For editor testing
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("BloomingFlowerEndScene");
    }

    // Call this to go back to MainMenu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Levels");
    }
}
