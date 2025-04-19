using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Ladeboard()
    {
        SceneManager.LoadScene("Ladeboard");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameLoop");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
