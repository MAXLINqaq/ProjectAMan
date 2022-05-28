using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;

    public float speed, jumpForce;
    public Transform GroundCheck1;
    public Transform GroundCheck2;
    public LayerMask ground;
    public bool isGround, isJump;
    public PhysicsMaterial2D withFriction;
    public PhysicsMaterial2D noFriction;
    bool jumpPressed;
    int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck1.position, 0.1f, ground) || Physics2D.OverlapCircle(GroundCheck2.position, 0.1f, ground);
        if (isGround)
        {
            rb.sharedMaterial = withFriction;
        }
        else
        {
            rb.sharedMaterial = noFriction;
        }

        GroundMovement();

        Jump();

    }
    void GroundMovement()
    {

        Vector3 obj = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector2 direction = Input.mousePosition - obj;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        float horizontal_move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal_move * speed, rb.velocity.y);
        /*if (horizontal_move != 0)
        {
            rb.velocity += new Vector2(horizontal_move * speed * Time.deltaTime * 10, 0);
        }
        if (rb.velocity.x <= -speed)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y);
        }
        if (rb.velocity.x >= speed)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y);
        }*/

        anim.SetFloat("isMoving", Mathf.Abs(horizontal_move));
    }
    void Jump()
    {
        if (Input.GetButton("Jump") && rb.velocity.y < 0)
        {
            rb.AddForce(new Vector3(0, 7, 0));
        }
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 3;
        }
        else
        {
            rb.gravityScale = 5;
        }

        if (isGround)
        {
            jumpCount = 1;
            isJump = false;
        }
        if (jumpPressed && isGround)
        {
            isJump = true;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
            jumpPressed = false;
        }
    }

}
