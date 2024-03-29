﻿using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;


public class CourseScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _groundCheckerRadius;
    
    [Header("UI")]
    [SerializeField] private TMP_Text _coinAmountText;
   
    private float _direction;
    private bool _jump;
    private float _lastPushTime;

    private void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jump = true;
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
        _animator.SetFloat("speed", Mathf.Abs(_direction));
        bool canJump = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);

        if (_jump && canJump)
        {
            _rigidbody.AddForce(Vector2.up * _jumpPower);
            _jump = false;
            _animator.SetBool("jump", true);         
        }
        if (!canJump)
        {
            _animator.SetBool("jump", false);
        }
    }
    public void TakeDamage(int damage, float pushPower = 0, float enemyPosX = 0)
    {
        _hp -= damage;
        HealthIndicator.Health = _hp;
        Debug.Log(_hp);
        if (_hp <= 0)
        {
            Debug.Log("Dead");
            gameObject.SetActive(false);
            ReloadScene();
        }
        if (pushPower != 0)
        {
            _lastPushTime = Time.time;
            int direction = transform.position.x > enemyPosX ? 1 : -1;
            _rigidbody.AddForce(new Vector2(direction * pushPower / 2, pushPower));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundChecker.position, _groundCheckerRadius);
    }
  
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Invoke(nameof(ReloadScene), 3f);
    }
}   

