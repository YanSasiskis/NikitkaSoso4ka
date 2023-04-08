using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killZoneScript : MonoBehaviour
{
    private CourseScript _player;
    [SerializeField] private int _damageOfZone;
    private void OnTriggerEnter2D(Collider2D other)
    {
        CourseScript player = other.GetComponent<CourseScript>();
        if (player != null)
        {
            Debug.Log("KillZone");
            player.TakeDamage(_damageOfZone);
        }
    }
}
