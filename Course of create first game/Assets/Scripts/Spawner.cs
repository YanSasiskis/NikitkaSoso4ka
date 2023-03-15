using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform _positionOfSpawn;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnemySpawner();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void EnemySpawner()
    {
        Instantiate(Enemy, _positionOfSpawn);
        Debug.Log("Suck dick");
    }
}

