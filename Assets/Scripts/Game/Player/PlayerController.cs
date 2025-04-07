using System;
using Game.Operation;
using Game.Operation.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float jumpSpeed = 5.0f;

        public double score = 0.0d;
        
        public static event Action<double> OnScoreChange;
        
        private Rigidbody2D _rb;
        private Collider2D _col;
        private PlayerInput _playerInput;
        
        private bool _isDucking;
        private bool _isJumping;

        private Lane _currentLane = Lane.Middle;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
            _col = GetComponent<Collider2D>();

            _rb.gravityScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnMoveLeft(InputValue value)
        {
            if (_currentLane == Lane.Left) return;
            _rb.MovePosition(new Vector2(_rb.position.x - jumpSpeed, _rb.position.y));
            _currentLane--;
        }

        void OnMoveRight()
        {
            if (_currentLane == Lane.Right) return;
            _rb.MovePosition(new Vector2(_rb.position.x + jumpSpeed, _rb.position.y));
            _currentLane++;
        }
        
        void OnJump()
        {
            _isJumping = true; 
        }

        void OnDuck()
        {
            _isDucking = true;
        }

        private void GetStunned()
        {
        }

        private void ModifyScore(IOperation operation)
        {
            score = operation.Evaluate(score);
            OnScoreChange?.Invoke(score);
            Debug.Log($"Current player score: {score}");
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                GetStunned(); 
            }

            if (other.gameObject.CompareTag("Operation"))
            {
                ModifyScore(other.gameObject.GetComponent<OperationController>().Operation);
            }
        }

    }
}
