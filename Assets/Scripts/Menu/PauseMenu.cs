using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel; // Panel pauzy
    [SerializeField] private string mainMenuSceneName = "MainMenu"; // Nazwa sceny głównego menu

    private bool isPaused = false; // Flaga pauzy

    void Start()
    {
        // Wyłącz menu pauzy na starcie
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Nie przypisano obiektu Pause Menu Panel w inspektorze!");
        }
    }

    void Update()
    {
        // Obsługa klawisza Escape do pauzowania
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
        isPaused = true; // Ustaw flagę pauzy na true
        Time.timeScale = 0f; // Zatrzymanie czasu gry
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(true); // Wyświetlenie panelu pauzy
        }
    }

    public void ResumeGame()
    {
        isPaused = false; // Ustaw flagę pauzy na false
        Time.timeScale = 1f; // Wznowienie czasu gry
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false); // Ukrycie panelu pauzy
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Reset czasu gry przed przejściem do menu głównego
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Załaduj scenę głównego menu
    }

    public void QuitGame()
    {


        Application.Quit();

    }
}
