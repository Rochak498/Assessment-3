using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingscene: MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("FlowerLeveling");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // For editor testing
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("FlowerLevelingEndScene");
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
