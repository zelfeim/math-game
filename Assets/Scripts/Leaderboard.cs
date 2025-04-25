using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using System.IO;
using System;

[Serializable]
public class LeaderboardEntry
{
    public string Username;
    public int Score;
}

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    private List<LeaderboardEntry> _entries = new List<LeaderboardEntry>();
    private string savePath;

    void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
        LoadLeaderboard();
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        // Sortowanie malejąco po wyniku (działa także dla wartości ujemnych)
        _entries = _entries.OrderByDescending(e => e.Score).ToList();

        int loopLength = Mathf.Min(_entries.Count, names.Count);
        for (int i = 0; i < loopLength; i++)
        {
            names[i].text = $"{i + 1}. {_entries[i].Username}";
            scores[i].text = _entries[i].Score.ToString();
        }
        for (int i = loopLength; i < names.Count; i++)
        {
            names[i].text = "";
            scores[i].text = "";
        }
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        var existingEntry = _entries.FirstOrDefault(e => e.Username == username);
        if (existingEntry != null)
        {
            if (score > existingEntry.Score)
            {
                existingEntry.Score = score;
                SaveLeaderboard();
            }
        }
        else
        {
            _entries.Add(new LeaderboardEntry { Username = username, Score = score });
            SaveLeaderboard();
        }
        GetLeaderboard();
    }

    private void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(new LeaderboardWrapper { entries = _entries }, true);
        File.WriteAllText(savePath, json);
    }

    private void LoadLeaderboard()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            var wrapper = JsonUtility.FromJson<LeaderboardWrapper>(json);
            if (wrapper != null && wrapper.entries != null)
                _entries = wrapper.entries;
        }
    }

    [Serializable]
    private class LeaderboardWrapper
    {
        public List<LeaderboardEntry> entries = new List<LeaderboardEntry>();
    }
}
