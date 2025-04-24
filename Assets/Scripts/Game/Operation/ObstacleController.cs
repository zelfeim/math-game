using Game.Operation.Interfaces;
using System;
using TMPro;
using UnityEngine;

namespace Game.Operation
{
    public class ObstacleController : MonoBehaviour
    {
        private float _speed = -2.0f;
        
        private Rigidbody2D _rb;
        private Collider2D _col;
        private SpriteRenderer _sr;
        public TextMeshPro text;
        
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _col = GetComponent<Collider2D>();
            text = GetComponent<TextMeshPro>();
            DifficultyManager.OnDifficultyChanged += UpddateDifficulty;
        }

        private void UpddateDifficulty(Difficulty difficulty)
        {
            _speed = DifficultyManager.Config.levels[(int)difficulty].speed;
        }

        void Update()
        {
        }

        private void FixedUpdate()
        {
            _rb.linearVelocityY = _speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Obstacle Collision!");
            Destroy(gameObject);
        }
    }
}
