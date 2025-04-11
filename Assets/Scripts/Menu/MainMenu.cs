using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameLoop");
    }
    public void QuitGame()
    {
        Application.Quit();
    }   
}
