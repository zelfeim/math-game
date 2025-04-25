using Game.Operation.Interfaces;
using TMPro;
using UnityEngine;

namespace Game.Operation
{
    public class OperationController : MonoBehaviour
    {
        public TextMeshPro text;
        private readonly float speed = -2.0f;
        private Collider2D _col;

        private Rigidbody2D _rb;
        private SpriteRenderer _sr;

        // TODO: Private?
        public IOperation Operation;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _col = GetComponent<Collider2D>();
            text = GetComponent<TextMeshPro>();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void FixedUpdate()
        {
            _rb.linearVelocityY = speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
    }
}