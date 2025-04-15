using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingscene : MonoBehaviour
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

    public void LoadFlowerLevelingScene()
    {
        SceneManager.LoadScene("FlowerLeveling"); // make sure the name matches your scene name!
    }
}