using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level"); //replay the game
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu"); //brings player to main menu scene
    }
}
