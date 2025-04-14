using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    // This method can be called by a UI button
    public void LoadMainMenu()
    {
        // Replace scene with the index of your Main Menu scene in Build Settings
        SceneManager.LoadScene("Levels");
    }
}
