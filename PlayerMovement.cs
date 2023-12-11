using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float direction;
    private  Rigidbody2D rb;
    //Jump
    public float jumpForce;
   
    public Transform groundCheck;
    public float groundcheckRadius;
    public LayerMask groundLayer;
    private bool isGrounded;
    private SpriteRenderer sr;
    private Animator anim;

    //new

    //dash
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    public TrailRenderer tr;

    

    // Start is called before the first frame update

  



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }



        if (!PauseMenu.instance.isPaused)
        {





            direction = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundcheckRadius, groundLayer);


            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                AudioManager.instance.PlaySFX(1);

            }


            if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(Dash());
            }


            if (rb.velocity.x < 0)
            {
                sr.flipX = true;
            }
            else if (rb.velocity.x > 0)
            {
                sr.flipX = false;
            }

        }

        anim.SetFloat("moveSpeed", Mathf.Abs( rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        float dashDirection = sr.flipX ? -1f : 1f;
        rb.velocity = new Vector2(dashDirection * dashingPower, 0f);
       

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }
}
