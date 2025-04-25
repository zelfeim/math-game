using System;
using Game.Misc;
using Game.Operation;
using Game.Operation.Interfaces;
using Menu;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        private const float HorizontalMoveSpeed = 15.0f;

        private int _lives = 3;
        private double _score = 0.0d;

        public static event Action<double> OnScoreChange;
        public static event Action<int> OnLivesChange;

        public PauseMenu PauseMenu;

        public GameObject explosionPrefab;


        private Rigidbody2D _rb;
        private Collider2D _col;
        private PlayerInput _playerInput;

        private Lane _currentLane = Lane.Middle;
        private bool _isMoving;
        private Vector2 _targetPosition;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
            _col = GetComponent<Collider2D>();

            _rb.gravityScale = 0;
            _targetPosition = _rb.position;

            OnScoreChange?.Invoke(_score);
            OnLivesChange?.Invoke(_lives);
        }

        private void FixedUpdate()
        {
            if (!_isMoving) return;

            var newPosition = Vector2.MoveTowards(_rb.position, _targetPosition, HorizontalMoveSpeed * Time.fixedDeltaTime);
            _rb.MovePosition(newPosition);

            if (Vector2.Distance(_rb.position, _targetPosition) >= 0.1f) return;

            _rb.MovePosition(_targetPosition);
            _isMoving = false;
        }

        private void OnMoveLeft(InputValue value)
        {
            if (_isMoving || _currentLane == Lane.Left) return;

            _currentLane--;
            UpdateTargetPosition();
        }

        private void OnMoveRight()
        {
            if (_isMoving || _currentLane == Lane.Right) return;

            _currentLane++;
            UpdateTargetPosition();
        }

        private void UpdateTargetPosition()
        {
            _targetPosition = new Vector2(_currentLane.GetXCoordinate(), _rb.position.y);
            _isMoving = true;
        }

        private void GetStunned()
        {
            _lives--;
            if (_lives < 1)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                PauseMenu.gameOver();
            }
            OnLivesChange?.Invoke(_lives);
        }

        private void ModifyScore(IOperation operation)
        {
            _score = operation.Evaluate(_score);
            OnScoreChange?.Invoke(_score);
            Debug.Log($"Current player score: {_score}");
        }

        public double GetCurrentScore()
        {
            return _score;
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