using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Game.Misc;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private TextController textController;
    [SerializeField] private Ladeboard leaderboard;

    [Header("Settings")]
    [SerializeField] private int maxUsernameLength = 10;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        var username = inputName.text.Trim();
        if (string.IsNullOrEmpty(username)) return;

        if (username.Length > maxUsernameLength)
            username = username.Substring(0, maxUsernameLength);

        int score = textController.GetLastDisplayedScore();

        submitScoreEvent.Invoke(username, score);
        leaderboard.SetLeaderboardEntry(username, score);
    }
}
