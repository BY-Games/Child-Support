using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childBox : MonoBehaviour
{

    public float standingCheckRadius = 0.1f;
    public LayerMask standingLayer;

    private Rigidbody2D rb;
    private bool isStandingOnBox = false;


    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isStandingOnBox = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isStandingOnBox = false;
        }
    }

    private void FixedUpdate()
    {


        // If the player is standing on the box, set its Rigidbody2D to kinematic
        if (isStandingOnBox)
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }
    }
}
