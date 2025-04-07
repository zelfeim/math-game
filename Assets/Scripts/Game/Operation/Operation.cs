using UnityEngine;

namespace Game.Operation
{
    public class Operation : IOperation
    {
        public void Spawn(Vector2 position)
        {
            Debug.Log($"Spawning operation at position {position}");
        }  
    }
}