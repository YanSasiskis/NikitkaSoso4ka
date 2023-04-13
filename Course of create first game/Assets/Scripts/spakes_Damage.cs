using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spakes_Damage : MonoBehaviour
{
    [SerializeField] private int _damageOfSpakes;
    private float _timeDelay = 1f;
    private float _lastTimeDamage;
    private CourseScript _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CourseScript player = other.GetComponent<CourseScript>();
        if (player != null)
        {
            player.TakeDamage(_damageOfSpakes);
            _lastTimeDamage = Time.time;
            _player = player;
        }
    }
    private void Update()
    {
       // ����� ����������� ��� � OnTriggerStay2D, ������ ��� � ������ ���� � ���� ����� ����� �����, ��� ��� �����     
       // ��������� �������� ����� update. ����� ��� �����������.
       if (_player != null && Time.time - _lastTimeDamage > _timeDelay)
        {
            _lastTimeDamage = Time.time;
            _player.TakeDamage(_damageOfSpakes);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        CourseScript player = other.GetComponent<CourseScript>();
        if (_player == player)
        {
            _player = null;
        }
    }
}

