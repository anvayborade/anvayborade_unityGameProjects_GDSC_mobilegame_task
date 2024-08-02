using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject gameOverUI;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameOverUI.SetActive(false); // Ensure Game Over UI is hidden at the start
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touchPosition.x < transform.position.x)
            {
                moveVelocity = Vector2.left * speed;
            }
            else if (touchPosition.x > transform.position.x)
            {
                moveVelocity = Vector2.right * speed;
            }
        }
        else
        {
            moveVelocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingObject"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverUI.SetActive(true); // Show Game Over UI
        Time.timeScale = 0f; // Pause the game
    }
}
