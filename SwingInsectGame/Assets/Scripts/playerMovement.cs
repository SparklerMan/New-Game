using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    private float moveInput;
    public float moveSpeed;
    public bool jumpInput;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRaduis;
    public LayerMask whatIsGround;
    public LayerMask Hookable;

    private float extraJumps;
    public float extraJumpsValue;
    public float jumpForce;

    public GameObject effect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //rb variable is the rigidbody on our player object
    }


    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRaduis, whatIsGround | Hookable);
        moveInput = Input.GetAxisRaw("Horizontal");
		jumpInput = Input.GetKeyDown(KeyCode.W);
        //Checking wether the player is on the ground or not

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (jumpInput == true && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
    }
    void FixedUpdate()
    {

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //move left and right


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("killMe"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
