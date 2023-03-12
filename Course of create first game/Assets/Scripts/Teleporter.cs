using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        CourseScript player = other.GetComponent<CourseScript>();
        if (player != null)
        {
            SceneManager.LoadScene("Scene_2");
            Debug.Log("Загрузка сцены #2");
        }
    }
}
