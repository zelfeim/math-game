using System;
using Game.Operation.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Operation
{
    public class OperationController : MonoBehaviour
    {
        private float speed = -2.0f;
        
        private Rigidbody2D _rb;
        private Collider2D _col;
        private SpriteRenderer _sr;
        public TextMeshPro text;
        
        // TODO: Private?
        public IOperation Operation;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _col = GetComponent<Collider2D>();
            text = GetComponent<TextMeshPro>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void FixedUpdate()
        {
            _rb.linearVelocityY = speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Operation destroyed!");
            Destroy(gameObject);
        }
    }
}
