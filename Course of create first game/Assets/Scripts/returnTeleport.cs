using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnTeleport : MonoBehaviour
{
    void Update()
    {
        // Ћучше закрыть карту чем использовать такой класс.
        if (transform.position.y < -15) // дл€ -15 нужно создать переменную, иначе другой человек может не пон€ть, что это 
        {                               // «а магическое число.
            transform.position = new Vector2(-9.56437f, 1); // Vector2 Ћучше создать SerializeField, чтобы ты мог задавать
        }                                                   // нужную тебе координату. Ќу и снова же, должно быть в виде переменной
    }                                                       // „тобы другой человек понимал, что это стартова€ позици€.
}
