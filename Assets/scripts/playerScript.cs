using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 10;
    public float jumpforce = 1000;
    public float collisionDetectorRadius = 0.35f;
    public Animator animator;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundlayer;
   

    private float h = 0;
    private float v = 0;
    bool isGrounded = true; 

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        JumpPlayer();
    }

    void FixedUpdate()
    {
        AnimatePlayer();  
    }

    void MovePlayer()
    {
        h = 0;
        v = 0;

        h = Input.GetKey("d")? 1 : h;
        h = Input.GetKey("a")? -1 : h;
        
        rb.velocity = new Vector3(h * Time.deltaTime * speed, rb.velocity.y, 0);
        RotatePlayer();

    }

    void JumpPlayer()
    {
        v = Input.GetKeyDown("w") ? 1 : v;
        if (!isGrounded) isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.35f, groundlayer);
        if (v != 0 && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpforce, 0);
            isGrounded = false;
        }
    }

    void RotatePlayer()
    {
        if (h < 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
        else if (h>0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
    }

    void AnimatePlayer()
    {
        if(h!=0)
            animator.SetBool("moving", true); 
        else
            animator.SetBool("moving", false);
    }
}
