using System;
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
                
            Instantiate(operationPrefab, new Vector3(lane * 5.0f, spawnerLocation.position.y, 0), Quaternion.identity);
            Debug.Log($"Spawning at: {lane * 5.0f}, {spawnerLocation.position.y}");

            _timer = 0;
        }
    }
}