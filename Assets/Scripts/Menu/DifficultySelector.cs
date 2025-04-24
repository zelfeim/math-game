using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DifficultySelector : MonoBehaviour
{
    public TMP_Text difficultyText; 
    private string[] difficulties = { "Easy", "Medium", "Hard" };
    private int currentIndex = 0;

    public static string SelectedDifficulty { get; private set; }

    void Start()
    {
        UpdateDifficulty();
    }

    public void NextDifficulty()
    {
        currentIndex = (currentIndex + 1) % difficulties.Length;
        UpdateDifficulty();
    }

    public void PreviousDifficulty()
    {
        currentIndex = (currentIndex - 1 + difficulties.Length) % difficulties.Length;
        UpdateDifficulty();
    }

    private void UpdateDifficulty()
    {
        SelectedDifficulty = difficulties[currentIndex];
        difficultyText.text = SelectedDifficulty;
        Debug.Log("Difficulty set to: " + SelectedDifficulty);
    }
}