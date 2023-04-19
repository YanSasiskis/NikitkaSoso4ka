
using UnityEngine;
//Лишне using
public class HealthIndicator : MonoBehaviour
{
    // В идеале, в этом классе хранить логику TakeDamage, IncreaseHitPoints
    public static int Health;
    public GameObject Heart1, Heart2, Heart3;

    private void Start()
    {
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
    }
    //Лишне абзацы
    //Лишне абзацы
    //Лишне абзацы
    void Update()
    {
        switch (Health)
        {
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                break;    
        
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                break;
        
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                break;
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                break;
        }
    }
}
