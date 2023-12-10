using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    // Call this method when the Play button is clicked
    public void PlayGame()
    {
        // Load the first scene of the game. Replace "GameScene" with your scene's name.
        SceneManager.LoadScene("Level1");
    }

    // Call this method when the Exit button is clicked
    public void ExitGame()
    {
        // Quit the game. Note: This will only work in a built game, not in the Unity Editor.
        Application.Quit();
    }
}
