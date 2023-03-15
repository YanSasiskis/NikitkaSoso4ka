using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimer : MonoBehaviour
{
    [SerializeField] private float _walkRange;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private bool _faceRight;

    private Vector2 _startPosition;
    private int _direction = 1;
    private Vector2 _drawPosition
    {
        get
        {
            if (_startPosition != Vector2.zero)
            {
                return transform.position;
            }
            else
            {
                return _startPosition;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_drawPosition, new Vector3(_walkRange * 2, 1, 0));
    }
    private void Start()
    {
        _startPosition = transform.position;
    }
    private void Update()
    {
        if (_faceRight && transform.position.x > _startPosition.x + _walkRange)
        {
            FlipFace();
        }
        else if (!_faceRight && transform.position.x < _startPosition.x - _walkRange)
        {
            FlipFace();
        }
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = Vector2.right * _direction * _speed;
    }
    private void FlipFace()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0, 180, 0);
        _direction *= -1;
    }
}
