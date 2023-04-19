using UnityEngine;

public class heal : MonoBehaviour
{
    [SerializeField] private int _hpPoints;
    [SerializeField] private Animator _animator;
    private int _hp;
    private void OnTriggerEnter2D(Collider2D  other)
    {
       CourseScript player = other.GetComponent<CourseScript>(); 
       if (player != null && HealthIndicator.Health !=3)
       {
            IncreaseHP(_hpPoints);
            _animator.SetBool("smoke", true);
            Invoke(nameof(Destroy), 0.3f);
       }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    public void IncreaseHP(int hpPoints) 
    {
        _hp += hpPoints;
        HealthIndicator.Health = _hp;
        Debug.Log("HP has been increased" + hpPoints);
    }
}
