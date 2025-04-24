using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Game.Misc;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputName;
    [FormerlySerializedAs("textController")] [SerializeField] private ScoreTextController scoreTextController;
    [SerializeField] private Leaderboard leaderboard;

    [Header("Settings")]
    [SerializeField] private int maxUsernameLength = 10;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        var username = inputName.text.Trim();
        if (string.IsNullOrEmpty(username)) return;

        if (username.Length > maxUsernameLength)
            username = username.Substring(0, maxUsernameLength);

        int score = scoreTextController.GetLastDisplayedScore();

        submitScoreEvent.Invoke(username, score);
        leaderboard.SetLeaderboardEntry(username, score);
    }
}
