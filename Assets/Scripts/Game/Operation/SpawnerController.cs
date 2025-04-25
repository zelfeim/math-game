using System;
using Game.Difficulty;
using Game.Misc;
using Game.Operation.BinaryTree;
using Game.Operation.Interfaces;
using UnityEngine;
using Range = Game.Difficulty.Range;

namespace Game.Operation
{
    public class SpawnerController : MonoBehaviour
    {
        public GameObject[] operationPrefab;
        public Transform spawnerLocation;
        
        private float _obstacleToOperationRatio;
        private Range _elementDensityRange;
        
        private float _spawnTimer = 0;
        private float _nextSpawnTime;

        private void Start()
        {
            _obstacleToOperationRatio = DifficultyManager.GetObstacleToOperationRatio();
            _elementDensityRange = DifficultyManager.GetElementDensityRange();
            
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
            return UnityEngine.Random.value * (_elementDensityRange.max - _elementDensityRange.min) + _elementDensityRange.min;
        }

        private void SpawnRandomObject()
        {
            if (UnityEngine.Random.value > _obstacleToOperationRatio)
            {
                SpawnOperation();
            }
            else
            {
                SpawnObstacle();
            }
        }

        private void SpawnObstacle()
        {
            var lanes = Enum.GetValues(typeof(Lane));
            var lane = (Lane)lanes.GetValue(UnityEngine.Random.Range(0, lanes.Length));
            
            var operationObject = Instantiate(operationPrefab[1], new Vector3(lane.GetXCoordinate(), spawnerLocation.position.y, 0), Quaternion.identity);

            operationObject.GetComponentInChildren<ObstacleController>();
        }

        private void SpawnOperation()
        {
            var lanes = Enum.GetValues(typeof(Lane));
            var lane = (Lane)lanes.GetValue(UnityEngine.Random.Range(0, lanes.Length));
            
            var operationObject = Instantiate(operationPrefab[0], new Vector3(lane.GetXCoordinate(), spawnerLocation.position.y, 0), Quaternion.identity);

            // TODO: Better performance?
            var controller = operationObject.GetComponentInChildren<OperationController>();
            
            var operation = CreateRandomOperation();
            
            controller.Operation = operation;
            controller.text.SetText(operation.BinaryTree.ToString());
        }

        private static readonly BinaryTreeFactory Factory = new();
        
        private static IOperation CreateRandomOperation()
        {
            var operationTree = Factory.CreateTree();
            
            return new Operation(operationTree);
        }
    }
}
