using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// лишние

public class PlantEnemy : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private Transform _mazzle;
    [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private float _projectileSpeed;
    // _canShoor должен быть после SerializeFields, на строке 19
    private bool _canShoot;

    [Header("Animation")]
    [SerializeField] private Animator _animator;
    [SerializeField] private string _shootAnimationKey;
    [SerializeField] private bool _faceRight;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(_attackRange, 1,0));
    }
    private void FixedUpdate()
    {
        // “акие if можно писать в одно строчку: if(_canShoot) return; 
        if (_canShoot)
        {
            return;
        }
        CheckIfCanShoot();
    }
    private void CheckIfCanShoot()
    {
        Collider2D player = Physics2D.OverlapBox(transform.position, new Vector2(_attackRange, 1), 0,_whatIsPlayer);
        if (player != null)
        {
            _canShoot = true;
            StartShoot(player.transform.position);
        }
        else
        {
            _canShoot = false;
        }
    }
    private void StartShoot(Vector2 playerPosition)
    {
        if (transform.position.x > playerPosition.x && !_faceRight || transform.position.x < playerPosition.x && _faceRight)
        {
            _faceRight = !_faceRight;
                transform.Rotate(0, 180, 0);
        }     
        _animator.SetBool(_shootAnimationKey, true);
    }
    public void Shoot()
    {
        // –еализовать ObjectPool, каждый раз создавать пулю затратно
        Rigidbody2D bullet = Instantiate(_bullet, _mazzle.position, Quaternion.identity);
        if (!_faceRight)
        {
            bullet.transform.Rotate(0, 180, 0);
        }
        bullet.velocity = _projectileSpeed * transform.right;
        _animator.SetBool(_shootAnimationKey, false);
        Invoke(nameof(CheckIfCanShoot), 1);
    }
}
