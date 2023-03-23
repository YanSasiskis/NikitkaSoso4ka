using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _timeOfDisappereance;
    [SerializeField] private int _damageOfBullet;
    private CourseScript _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CourseScript player = other.GetComponent<CourseScript>();
        if (player != null)
        {
            player.TakeDamage(_damageOfBullet);
        }
        Destroy(gameObject);
    }
    private void Start()
    {
        Invoke(nameof(Destroy), _timeOfDisappereance);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
