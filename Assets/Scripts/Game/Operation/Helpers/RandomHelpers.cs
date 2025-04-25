using UnityEngine;

namespace Game.Operation.Helpers
{
    public static class RandomHelpers
    {
        public static double GetRandomOperationValue()
        {
            return Random.Range(1, 20);
        }
    }
}