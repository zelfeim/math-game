using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    InMainMenu,
    Playing,
    Paused
}

public class GameController : MonoBehaviour
{
    void Start()
    {
        
    }

    public static void StartGame()
    {
    }

    private void SetState(GameState state)
    {
    }
}