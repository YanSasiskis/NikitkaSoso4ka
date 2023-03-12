using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CourseScript player = collision.gameObject.GetComponent<CourseScript>();
        if (player != null)
        {
            Debug.Log("dsd");
        }
    }
}
