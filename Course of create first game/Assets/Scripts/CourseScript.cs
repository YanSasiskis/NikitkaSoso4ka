using UnityEngine;
using System;
using UnityEngine.Serialization;
using TMPro;

public class CourseScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Animator _animator;
    [Header("UI")]
    [SerializeField] private TMP_Text _coinAmountText;
    [SerializeField] private int _hp;

    public int CoinsAmount
    {
        get
        {
            return _coinsAmount;
        }
        set
        {
            _coinsAmount = value;
            _coinAmountText.text = "Coins: " + value.ToString();
        }
    }
  
    private int _coinsAmount;
    private float _direction;
    private bool _jump;
    private void Start()
    {
        CoinsAmount = 0;
    }

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
        if (_hp == 0)
        {
            Destroy(gameObject);
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
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundChecker.position, _groundCheckerRadius);
    }
    
    public void IncreaseHP(int hpPoints)
    {      
        Debug.Log("HP has been increased" + hpPoints);
    }
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        Debug.Log("HP has been increased by 1 HP");
        Debug.Log(_hp);
    }
}   

