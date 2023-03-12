using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    [SerializeField] private int _coinsAmount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        CourseScript player = other.GetComponent<CourseScript>();     
        if (player != null)
        {
            player.CoinsAmount += _coinsAmount;
            Destroy(gameObject);
            Debug.Log("Монет: " + player.CoinsAmount);
        }
    }
    
}   
