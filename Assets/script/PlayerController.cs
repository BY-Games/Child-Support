using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float pushForce = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("box"))
        {
            // Apply a force to the box in the direction of the player's movement
          //  Vector2 pushDirection = new Vector2(rb.velocity.x, 0f).normalized;
           // collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

            // Apply a force to the player to simulate jumping off the box
           // rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
