using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private int _direction = 1;
       
    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector2.left * _direction * _speed;
    }
    
}


