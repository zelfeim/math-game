using System;
using UnityEngine;

namespace Game.Operation
{
    public class OperationUnloaderController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Unload operation");
            Destroy(other.gameObject);
        }
    }
}