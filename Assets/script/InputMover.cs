using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputMover : MonoBehaviour
{
    [Tooltip("The horizontal force that the player's feet use for walking, in newtons.")]
    [SerializeField] float walkForce = 5f;
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;
    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);


    [Tooltip("The vertical force that the player's feet use for jumping, in newtons.")]
    [SerializeField] float jumpImpulse = 5f;
    [SerializeField] InputAction jump;
    [SerializeField] Vector3 velocity = Vector3.zero;
    [SerializeField] Vector3 acceleration = new Vector3(0, -10, 0);
    [SerializeField] bool isTouchingTheGround = false;
    [SerializeField] bool isTouchingTheBox = false;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;


    bool playerWantsToJump = false;

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnValidate()
    {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261
        if (jump == null)
            jump = new InputAction(type: InputActionType.Button);
        if (jump.bindings.Count == 0)
            jump.AddBinding("<Keyboard>/space");

        if (moveHorizontal == null)
            moveHorizontal = new InputAction(type: InputActionType.Button);
        if (moveHorizontal.bindings.Count == 0)
            moveHorizontal.AddCompositeBinding("1DAxis")
                .With("Positive", "<Keyboard>/rightArrow")
                .With("Negative", "<Keyboard>/leftArrow");
    }

    void OnEnable()
    {
        moveHorizontal.Enable();
        jump.Enable();
    }

    void OnDisable()
    {
        moveHorizontal.Disable();
        jump.Disable();
    }

    private void OnCollisionEnter2D(Collision2D c)
    {

        if (c.collider.tag == "Ground")
        {

            isTouchingTheGround = true;

        }

        if (c.collider.tag == "box")
        {
            isTouchingTheBox = true;
        }





    }

    private void OnCollisionExit2D(Collision2D c)
    {
        if (c.collider.tag == "Ground")
        {
            isTouchingTheGround = false;
        }

        if (c.collider.tag == "box")
        {
            isTouchingTheBox = false;
        }

    }

    void Update()
    {
        float horizontal = moveHorizontal.ReadValue<float>();

        Vector3 movementVector = new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;
        transform.position += movementVector;
        UpdateAnimation(horizontal);
        if (isTouchingTheGround && jump.WasPressedThisFrame())
        {
            Debug.Log("Player wants to jump");
            playerWantsToJump = true;
        }
        if (isTouchingTheBox && jump.WasPressedThisFrame())
        {
            Debug.Log("Player wants to jump");
            playerWantsToJump = true;
        }


    }


    private void UpdateAnimation(float horizontal)
    {
        //right dirction 
        //horizontal = 1
        if (horizontal > 0f)
        {

            spriteRenderer.flipX = false;
        }
        //left dirction 
        //horizontal = -1
        else if (horizontal < 0f)
        {

            spriteRenderer.flipX = true;

        }


    }



    private void FixedUpdate()
    {
        /*
       
        // Update velocity and position:
        if (playerWantsToJump)
        {
            Debug.Log("Jumping!");

            velocity = jumpImpulse * Vector3.up;

            playerWantsToJump = false;
        }
        if (isTouchingTheGround && velocity.y <= 0)
        {
            velocity = Vector3.zero;
        }
        else
        {
            velocity += acceleration * Time.fixedDeltaTime;
        }
        transform.position += velocity * Time.fixedDeltaTime;
    }
       
 */


        if (playerWantsToJump && isTouchingTheGround && velocity.y <= 0)
        {
            Debug.Log("Jumping!");

            // Add an impulse force to the Rigidbody
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
            playerWantsToJump = false;


        }
        else if (playerWantsToJump && isTouchingTheBox && velocity.y <= 0)
        {
            Debug.Log("Jumping!");

            // Add an impulse force to the Rigidbody
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
            playerWantsToJump = false;
        }
    }
}