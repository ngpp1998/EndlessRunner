using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level"); //load the game scene
    }
    public void QuitGame()
    {
        Application.Quit(); //quit the application
    }
}
