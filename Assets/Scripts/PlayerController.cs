using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public float move;

    public bool isGrounded;

    public LayerMask groundLayers;
    public Transform groundCheck;
    public float groundCheckRadius;

    public float jumpForce;
    public bool isFacingRight;
    public bool isAttacking;
    public bool attack1;
    public bool attack2;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {

                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            }

        }

        attack1 = Input.GetButtonDown("Fire1");
        attack2 = Input.GetButtonDown("Fire2");

        if (attack1 && isAttacking == false)
        {
            Attack();
        }

        if (attack2 && isAttacking == false)
        {
            Attack2();
        }

    }
    void FixedUpdate()
    {

        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if ((move > 0.0f && isFacingRight == false)|| (move < 0.0f && isFacingRight == true))
        {
            Flip();
        }
    }

    private void LateUpdate()
    {
        animator.SetBool("Idle", move == 0f);
        animator.SetFloat("VerticalVelocity", rb.velocity.y);

        if ((animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack1")) || (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack2")))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack1");
    }

    void Attack2()
    {
        animator.SetTrigger("Attack2");
    }


    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x = playerScale.x * -1;
        transform.localScale = playerScale;
    }


}
