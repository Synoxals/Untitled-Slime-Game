using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float x;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private string Axis;
    private string Jump;
    [SerializeField] private bool isFacingRight = false;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform groundCheck;


    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "PinkSlime")
        {
            Axis = "PinkHorizontal";
            Jump = "PinkJump";
        }
        else if (this.name == "PurpleSlime")
        {
            Axis = "PurpleHorizontal";
            Jump = "PurpleJump";
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw(Axis);
        if (Input.GetButtonDown(Jump) && IsGrounded())
        {
            Debug.Log("Jump Pressed");
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, ground);
    }

    private void Flip()
    {
        if (isFacingRight && x > 0f || !isFacingRight && x < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
