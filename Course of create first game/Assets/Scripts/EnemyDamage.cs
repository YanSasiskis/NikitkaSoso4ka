using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    private float _lastDamageTime = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CourseScript player = collision.gameObject.GetComponent<CourseScript>();
        if (player != null && Time.time - _lastDamageTime > 1f)
        {
            _lastDamageTime = Time.time;
            player.TakeDamage(_damage);
        }
    }
}
