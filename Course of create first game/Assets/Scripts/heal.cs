using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    [SerializeField] private int _hpPoints;
    
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        CourseScript player = other.gameObject.GetComponent<CourseScript>();
        if (player != null)
        {
            player.IncreaseHP(_hpPoints);
            Destroy(gameObject);
        }
    }
    */

    
       private void OnTriggerEnter2D(Collider2D  other)
       {
           CourseScript player = other.GetComponent<CourseScript>(); // не работает метод триггер
           if (player != null)
           {
               player.IncreaseHP(_hpPoints);
               Destroy(gameObject);
           }
       }
    
    
}
