using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Лишние using

public class heal : MonoBehaviour
{
    [SerializeField] private int _hpPoints;
    [SerializeField] private Animator _animator;
    private void OnTriggerEnter2D(Collider2D  other)
    {
       CourseScript player = other.GetComponent<CourseScript>(); 
       if (player != null && HealthIndicator.Health !=3)
       {
            player.IncreaseHP(_hpPoints);
            _animator.SetBool("smoke", true);
            Invoke(nameof(Destroy), 0.3f);
       }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
