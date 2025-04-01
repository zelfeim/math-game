using System;
using UnityEngine;

namespace Game.Operation
{
    public class OperationUnloaderController : MonoBehaviour
    {
        public GameObject player;
        
        private BoxCollider2D boxCollider;

        void Awake()
        {
            boxCollider = GetComponent<BoxCollider2D>();
            boxCollider.isTrigger = true;
        }

        void Update()
        {
            transform.position = new Vector2(transform.position.x, player.transform.position.y - 4);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Unload operation");
            Destroy(other.gameObject);
        }
    }
}