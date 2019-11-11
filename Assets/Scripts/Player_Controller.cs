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

    [SerializeField]
    Transform GroundCheck;
    [SerializeField]
    Transform GroundCheckL;
    [SerializeField]
    Transform GroundCheckR;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            if(Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("spikes")) ||
                Physics2D.Linecast(transform.position, GroundCheckL.position, 1 << LayerMask.NameToLayer("spikes")) ||
                Physics2D.Linecast(transform.position, GroundCheckR.position, 1 << LayerMask.NameToLayer("spikes")))
            {
                    Dead = true;
                    animator.Play("Die");
                    Death_Screen.gameObject.SetActive(true);
                    
            }
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

                    animator.Play("Run_Right");
            }
            else if (!Dead && (Input.GetKey("a") || Input.GetKey("left")))
            {
                rb2d.velocity = new Vector2(-RunSpeed, rb2d.velocity.y);

                    animator.Play("Run_Left");
            }
            else
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);

                if (isGrounded)
                    animator.Play("Idle");
            }
            if (!Dead && (Input.GetKey("space") && isGrounded))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, JumpHeight);
            }
        }
    }
