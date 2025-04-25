using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void Leaderboard()
        {
            SceneManager.LoadScene("Leaderboard");
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
}