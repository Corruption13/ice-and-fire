using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode leftkey;
    public KeyCode rightkey;
    public KeyCode jumpkey;
    public KeyCode interactkey; 


    public int speed = 10;
    public float jumpforce = 1000;
    public float collisionDetectorRadius = 0.35f;
    public Animator animator;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundlayer;
   

    private float h = 0;
    private float v = 0;
    private float halfPlayerSizeX; 
    bool isGrounded = true;


    void Start()
    {
        halfPlayerSizeX = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    private void Update()
    {
        GetInput(); 
        
    }

    void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();
        AnimatePlayer();
        RotatePlayer();
    }


    void GetInput()
    {
        v = Input.GetKey(jumpkey) ? 1 : 0;
        h = Input.GetKey(rightkey) ? 1 : Input.GetKey(leftkey) ? -1 : 0;
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(h * Time.deltaTime * speed, rb.velocity.y);
        
    }

    void JumpPlayer()
    {
        
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
