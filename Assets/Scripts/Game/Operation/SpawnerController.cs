using System;
using Game.Operation.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace Game.Operation
{
    public class SpawnerController : MonoBehaviour
    {
        public GameObject operationPrefab;
        public Transform spawnerLocation;

        private readonly Random _random = new();
        private float _timer = 0;

        private void Update()
        {
            _timer += Time.deltaTime;
            SpawnOperations();
        }

        private void SpawnOperations()
        {
            if (!(_timer >= 2)) return;
            
            var lane = _random.Next(-1, 1);
                
            var operationObject = Instantiate(operationPrefab, new Vector3(lane * 10.0f, spawnerLocation.position.y, 0), Quaternion.identity);

            // TODO: Better performance?
            var controller = operationObject.GetComponent<OperationController>();
            
            var operation = RandomizeOperation();
            var text = string.Empty;

            var rhs = operation.Rhs.ToString("0.##");
            switch (operation)
            {
                case AdditionOperation additionOperation:
                    text = $"+{rhs}"; 
                    break;
                case SubtractionOperation subtractionOperation:
                    text = $"-{rhs}";
                    break;
                case MultiplicationOperation multiplicationOperation:
                    text = $"*{rhs}";
                    break;
                case DivisionOperation divisionOperation:
                    text = $"/{rhs}";
                    break;
            }
            
            controller.Operation = operation;
            controller.text.SetText(text);
            // controller.Setup(operation, text);

            _timer = 0;
        }

        private IOperation RandomizeOperation()
        {
            var type = _random.Next(1, 4);
            
            var value = _random.NextDouble() * 10;
            
            return type switch
            {
                // TODO: Set colors/values inside the operations
                1 => new AdditionOperation(value),
                2 => new SubtractionOperation(value),
                3 => new MultiplicationOperation(value),
                4 => new DivisionOperation(value),
                _ => null
            };
        }
    }
}