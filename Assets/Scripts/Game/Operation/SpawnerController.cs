using Game.Operation.Interfaces;
using UnityEngine;
using Random = System.Random;

namespace Game.Operation
{
    public class SpawnerController : MonoBehaviour
    {
        public GameObject operationPrefab;
        public Transform spawnerLocation;

        // TODO get from game difficulty config
        private const float OperationChance = 0.5f;
        private const float MinSpawnInterval = 0.5f;
        private const float MaxSpawnInterval = 2f;
        
        private readonly Random _random = new();
        private float _spawnTimer = 0;
        private float _nextSpawnTime;

        private void Start()
        {
            _nextSpawnTime = GetNextSpawnTime();
        }
        
        private void Update()
        {
            _spawnTimer += Time.deltaTime;

            if (_spawnTimer < _nextSpawnTime)
            {
                return;
            }
            
            SpawnRandomObject();
            _spawnTimer = 0;
            _nextSpawnTime = GetNextSpawnTime();
        }

        private float GetNextSpawnTime()
        {
            return (float)(_random.NextDouble() * (MaxSpawnInterval - MinSpawnInterval) + MinSpawnInterval);
        }

        private void SpawnRandomObject()
        {
            if (_random.NextDouble() > OperationChance)
            {
                SpawnOperations();
            }
            else
            {
                SpawnObstacle();
            }
        }

        private void SpawnObstacle()
        {
            // TODO: spawn obstacle
        }

        private void SpawnOperations()
        {
            var lane = _random.Next(-1, 2);
                
            var operationObject = Instantiate(operationPrefab, new Vector3(lane * 5.0f, spawnerLocation.position.y, 0), Quaternion.identity);

            // TODO: Better performance?
            var controller = operationObject.GetComponent<OperationController>();
            
            var operation = RandomizeOperation();
            
            controller.Operation = operation;
            controller.text.SetText(operation.BinaryTree.ToString());
        }

        private static IOperation RandomizeOperation()
        {
            return new Operation(2);
        }
    }
}
