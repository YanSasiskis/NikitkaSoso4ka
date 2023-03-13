using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    [SerializeField] private int _hpPoints; 
    private void OnTriggerEnter2D(Collider2D  other)
    {
       CourseScript player = other.GetComponent<CourseScript>(); // не работает метод триггер
       if (player != null && HealthIndicator.Health !=3)
       {
           player.IncreaseHP(_hpPoints);
           Destroy(gameObject);
        }
    }       
}
