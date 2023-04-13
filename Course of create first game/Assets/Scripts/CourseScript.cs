using UnityEngine;
using System;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.SceneManagement;

/*
    Удаляй using, который твой класс не использует. В таком случае, using горит серым. В данном классе это:
    System
    using UnityEngine.Serialization;
*/
public class CourseScript : MonoBehaviour
{
    // Сортируй данный по объему типа.
    /*
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _groundCheckerRadius;
    */
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


    // Создай отдельный класс Coins, у персонажа не должно быть логики, связанной с монетами.
    // Если ты будешь все возможные функции добавлять персонажу, он будет у тебя как швейцарский нож, а это - плохо.
    // Так как твой код будет расти, а ориентироваться в нем будет все сложнее и сложнее. 
    // Каждый класс должен отвечать только за то, что в нём должно быть.
    // Условно говоря, у персонажа должна быть анимация, скорость бега, скорость ходьбы, сила прыжка, урон. 
    // Даже HP у него не должно быть, так как это уже отдельный класс. 
    // Он должен использовать и хранить класс HP.
    // Выглядеть это будет так:
    /*
         public void TakeDamage(int damage, float pushPower = 0, float enemyPosX = 0)
         {
            _hp.TakeDamage(damage);
            if (pushPower != 0)
            {
                 _lastPushTime = Time.time;
                 int direction = transform.position.x > enemyPosX ? 1 : -1;
                 _rigidbody.AddForce(new Vector2(direction * pushPower / 2, pushPower));
            }
         }
     */
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
    private int _hp = 3;
    private int _coinsAmount;
    private float _direction;
    private bool _jump;
    private float _lastPushTime;
    private void Start()
    {
        HealthIndicator.Health = _hp;
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
    

    public void IncreaseHP(int hpPoints) // Должна быть в другом классе
    {
        _hp += hpPoints;
        HealthIndicator.Health = _hp;
        Debug.Log("HP has been increased" + hpPoints);
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
    
    // Очередность инкапсуляции :
    // Serialize
    // private
    // public
    // Эта функция должно быть выше, перед TakeDamage
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Invoke(nameof(ReloadScene), 3f);
    }
}   

