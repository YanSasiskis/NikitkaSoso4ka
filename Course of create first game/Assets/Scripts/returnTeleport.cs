using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnTeleport : MonoBehaviour
{
    void Update()
    {
        // ����� ������� ����� ��� ������������ ����� �����.
        if (transform.position.y < -15) // ��� -15 ����� ������� ����������, ����� ������ ������� ����� �� ������, ��� ��� 
        {                               // �� ���������� �����.
            transform.position = new Vector2(-9.56437f, 1); // Vector2 ����� ������� SerializeField, ����� �� ��� ��������
        }                                                   // ������ ���� ����������. �� � ����� ��, ������ ���� � ���� ����������
    }                                                       // ����� ������ ������� �������, ��� ��� ��������� �������.
}
