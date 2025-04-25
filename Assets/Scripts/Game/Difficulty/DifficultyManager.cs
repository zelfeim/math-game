using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Game.Difficulty
{
    public static class DifficultyManager
    {
        public static Difficulty CurrentDifficulty { get; set; } = Difficulty.Easy;

        private static DifficultyConfiguration _config;

        private static DifficultyConfiguration Config
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

        public static Range GetValueRange()
        {
             return GetCurrentDifficultyData().valueRange;
        }

        public static Range GetResultRange()
        {
            return GetCurrentDifficultyData().resultRange;
        }
        

        public static List<OperationData> GetOperations()
        {
            return GetCurrentDifficultyData().operations; 
        }

        public static int GetOperationComplexity()
        {
            return GetCurrentDifficultyData().operationComplexity;
        }

        public static float GetObstacleToOperationRatio()
        {
            return GetCurrentDifficultyData().obstacleToOperationRatio;
        }

        public static Range GetElementDensityRange()
        {
            return GetCurrentDifficultyData().elementDensityRange;
        }

        public static float GetObjectSpeed()
        {
            return GetCurrentDifficultyData().speed;
        }

        private static DifficultyData GetCurrentDifficultyData()
        {
            return CurrentDifficulty switch
            {
                Difficulty.Easy => Config.easy,
                Difficulty.Medium => Config.medium,
                Difficulty.Hard => Config.hard,
                Difficulty.Insane => Config.insane,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        // Initialize on first access
        static DifficultyManager()
        {
            LoadConfig();
        }

        private static void LoadConfig()
        {
            var jsonFile = Resources.Load<TextAsset>("difficulty");

            if (!jsonFile)
            {
                const string errorMessage = "LevelDataConfiguration.json not found in Resources folder!";
                Debug.LogError(errorMessage);
                throw new Exception(errorMessage);
            }
            _config = JsonConvert.DeserializeObject<DifficultyConfiguration>(jsonFile.text);
        }
    }
}