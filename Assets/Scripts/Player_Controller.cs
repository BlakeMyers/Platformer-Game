using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    public GameObject Death_Screen;

    [SerializeField]
    private float RunSpeed = 3.0f;
    [SerializeField]
    private float JumpHeight = 5.0f;


    bool isGrounded;
    bool Dead = false;

    public Transform GroundCheck;
    public Transform GroundCheckL;
    public Transform GroundCheckR;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("spikes"))
        {
            Dead = true;
            animator.Play("player_death");
            Death_Screen.gameObject.SetActive(true);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            if (Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
                Physics2D.Linecast(transform.position, GroundCheckL.position, 1 << LayerMask.NameToLayer("Ground")) ||
                Physics2D.Linecast(transform.position, GroundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
            if (!Dead && (Input.GetKey("d") || Input.GetKey("right")))
            {
                rb2d.velocity = new Vector2(RunSpeed, rb2d.velocity.y);

                    animator.Play("walk_right");
            }
            else if (!Dead && (Input.GetKey("a") || Input.GetKey("left")))
            {
                rb2d.velocity = new Vector2(-RunSpeed, rb2d.velocity.y);

                    animator.Play("walk_left");
            }
            else
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);

                if (isGrounded)
                    animator.Play("player_idle");
            }
            if (!Dead && (Input.GetKey("space") && isGrounded))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, JumpHeight);
            animator.Play("player_jump");
            }
        }
    }
