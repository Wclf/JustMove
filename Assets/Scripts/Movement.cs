using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float horizontalValue;
    private bool isGrounded = false;
    public static bool canMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        
    }
    private void Update()
    {
        if(canMove)
        {
            horizontalValue = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }
 

    }

    private void FixedUpdate()
    {
        GroundCheck();
        if(canMove)
        {
            Move(horizontalValue);

        }
    }

    void Move(float dir)
    {
        float xVal = horizontalValue * speed * 100 * Time.fixedDeltaTime;
        rb.velocity = new Vector2(xVal, rb.velocity.y);

    }

    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colider = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, groundLayer);
        if(colider.Length > 0 )
        {
            isGrounded = true;
        }
    }




}