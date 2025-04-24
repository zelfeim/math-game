using System.Collections.Generic;

[System.Serializable]
public class LevelData
{
    public int level;

    /// <summary>
    /// 
    /// </summary>
    public int[] valueRange;

    /// <summary>
    /// 
    /// </summary>
    public int[] resultRange;
    public string[] operations;
    public int operationComplexity;
    public float obstacleToOperationRatio;
    public string elementDensity;
    public float speed;
}

[System.Serializable]
public class LevelDataConfiguration
{
    public LevelData[] levels;
}

public enum Difficulty
{
    Easy = 1,
    Medium,
    Hard,
    Insane
}