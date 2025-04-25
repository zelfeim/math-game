using Game.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuPanel; // Panel pauzy
        [SerializeField] private string mainMenuSceneName = "MainMenu"; // Nazwa sceny głównego menu
        [SerializeField] private GameObject gameOverUI; // UI końca gry

        

        private bool isPaused = false; // Flaga pauzy

        void Start()
        {
            // Wyłącz menu pauzy na starcie
            if (pauseMenuPanel != null)
            {
                pauseMenuPanel.SetActive(false);
            }

            if (gameOverUI != null)
            {
                gameOverUI.SetActive(false);
            }

        }

        void Update()
        {
            if (gameOverUI != null && gameOverUI.activeSelf) return; 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        public void TogglePause()
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }


      

        public void PauseGame()
        {
            isPaused = true; 
            Time.timeScale = 0f; // Zatrzymanie czasu gry
            if (pauseMenuPanel != null)
            {
                pauseMenuPanel.SetActive(true); // Wyświetlenie panelu pauzy
            }
        }

        public void ResumeGame()
        {
            isPaused = false; 
            Time.timeScale = 1f; // Wznowienie czasu gry
            if (pauseMenuPanel != null)
            {
                pauseMenuPanel.SetActive(false); // Ukrycie panelu pauzy
            }
        }

        public void LoadMainMenu()
        {
            Time.timeScale = 1f; 
            SceneManager.LoadScene(mainMenuSceneName); 
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }

        public void gameOver()
        {
            StartCoroutine(ShowGameOverWithDelay());
        }

        private IEnumerator ShowGameOverWithDelay()
        {
            yield return new WaitForSeconds(1f); 
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true); 
            }
            Time.timeScale = 0f; 
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}