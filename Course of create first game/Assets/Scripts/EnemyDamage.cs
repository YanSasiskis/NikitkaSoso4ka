using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _pushPower;

    private float _lastDamageTime = 0;
    private float _damageDelay = 1f;
    private CourseScript _player;
    private void Update()
    {
        if (_player != null && Time.time - _lastDamageTime > _damageDelay)
        {
            Debug.Log("StayOnCollision");
            _lastDamageTime = Time.time;
            _player.TakeDamage(_damage);;
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CourseScript player = collision.gameObject.GetComponent<CourseScript>();
        if (player != null && Time.time - _lastDamageTime > _damageDelay)
        {
            Debug.Log("EnterCollision");
            _lastDamageTime = Time.time;
            player.TakeDamage(_damage,_pushPower,transform.position.x);
            _player = player;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        CourseScript player = collision.gameObject.GetComponent<CourseScript>();
        if (player == _player)
        {
            Debug.Log("Exit from collision");
            _player = null;           
        }
    }  
}
