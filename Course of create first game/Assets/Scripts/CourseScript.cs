using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private LayerMask _whatIsGround;

    private float _direction;
    private bool _jump;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jump = true;
            Debug.Log("Jump");
        }
        if (_direction > 0 && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_direction < 0 && !_spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = true;
        }            
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_direction * _speed, _rigidbody.velocity.y);
        
        bool canJump = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);
        
        if (_jump && canJump)
        {
            _rigidbody.AddForce(Vector2.up * _jumpPower);
            _jump = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundChecker.position, _groundCheckerRadius);
    }
}
