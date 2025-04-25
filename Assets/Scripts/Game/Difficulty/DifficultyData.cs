using System.Collections.Generic;
using Game.Operation.BinaryTree;
using Game.Operation.BinaryTree.Operations;

namespace Game.Difficulty
{
    [System.Serializable]
    public class DifficultyConfiguration
    {
        public DifficultyData easy, medium, hard, insane;
    }
    
    [System.Serializable]
    public class DifficultyData
    {
        public Range valueRange;
        public Range resultRange;
        public List<OperationData> operations;
        public int operationComplexity;
        public float obstacleToOperationRatio;
        public Range elementDensityRange;
        public float speed;
    }

    [System.Serializable]
    public class OperationData
    {
        public OperationType type;
        public int weight;
    }

    [System.Serializable]
    public class Range
    {
        public int min, max;
    }
}