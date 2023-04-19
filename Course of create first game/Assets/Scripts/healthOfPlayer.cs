using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthOfPlayer : MonoBehaviour
{
    private int _hp = 3;
    public int HP
    {
        get { return _hp; } 
        set { _hp = value; }
    }
    private void Start()
    {
        HealthIndicator.Health = _hp;
    }
    void Update()
    {
        
    }
}
