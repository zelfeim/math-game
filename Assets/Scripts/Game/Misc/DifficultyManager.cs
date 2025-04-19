using UnityEngine;

public static class DifficultyManager
{
    private static LevelDataConfiguration _config;

    public static LevelDataConfiguration Config
    {
        get
        {
            if (_config == null)
            {
                LoadConfig();
            }

            return _config;
        }
    }

    // Initialize on first access
    static DifficultyManager()
    {
        LoadConfig();
    }

    private static void LoadConfig()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("levels");

        if (jsonFile == null)
        {
            Debug.LogError("LevelDataConfiguration.json not found in Resources folder!");
            _config = new LevelDataConfiguration(); // Create empty config to prevent null references
            return;
        }
        _config = JsonUtility.FromJson<LevelDataConfiguration>("{\"levels\":" + jsonFile.text + "}");
    }
}