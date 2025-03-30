using System;
using UnityEngine;

public class Operation : MonoBehaviour
{
    private Rigidbody _rb;
    private Collider2D _col;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        // Destroy(gameObject);
    }
}
