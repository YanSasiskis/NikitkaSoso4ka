using UnityEngine;

public class ControllerChat : MonoBehaviour
{
    // Скорость перемещения персонажа
    public float moveSpeed = 5f;
    // Сила прыжка персонажа
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Управление влево и вправо
        float moveDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, коснулся ли персонаж земли
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}