using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Keyboard Controls")]
    public KeyCode leftkey;
    public KeyCode rightkey;
    public KeyCode jumpkey;
    public KeyCode interactkey;
    private bool isUsingTouchInput = false;


    [Header("Character Movement Stats")]
    public int speed = 10;
    public float jumpforce = 1000;
    public float collisionDetectorRadius = 0.35f;
    public float bottomOffset = 0.004f; 


    private Animator animator;
    private Rigidbody2D rb;


    [Header("JumpLayer")]
    public LayerMask groundlayer;
    public LayerMask MovableLayer;
    public LayerMask OtherPlayerLayer;

    private int h = 0;
    private int v = 0;
    private bool isGrounded;


    private void Start()
    {
        isGrounded = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isUsingTouchInput)
        {
            GetInput();
        }
        AnimatePlayer();
        RotatePlayer();
        RightSideUpPlayer();
        
    }

    void FixedUpdate()
    {
       
        MovePlayerHorizontal(h);
        if(v!=0)
            JumpPlayer(v);
    }


    void GetInput()
    {
        v = Input.GetKey(jumpkey) ? 1 : 0;
        h = Input.GetKey(rightkey) ? 1 : Input.GetKey(leftkey) ? -1 : 0;
    }

    void MovePlayerHorizontal(int horizontal)
    {
        if(horizontal != 0)
            rb.velocity = new Vector2(horizontal * Time.deltaTime * speed, rb.velocity.y);
        if(horizontal == 0)
        {
            if (!Physics2D.OverlapCircle(transform.position, collisionDetectorRadius, MovableLayer))
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        
    }

    public void MovePlayerLeftStart()
    {
        isUsingTouchInput = true;
        h = -1;
    }
    public void MovePlayerRightStart()
    {
        isUsingTouchInput = true;
        h = 1;
    }
    public void StopPlayerHorizontal()
    {
        isUsingTouchInput = false;
        h = 0;
    }

    public void JumpPlayer(int v)
    {
        isGrounded = ValidLayerCheck();
        if (v != 0 && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpforce, 0);
            isGrounded = false;
        }
    }

    private bool ValidLayerCheck()
    {
        return Physics2D.OverlapCircle(transform.position, collisionDetectorRadius, groundlayer) 
                || Physics2D.OverlapCircle(transform.position, collisionDetectorRadius, MovableLayer)
                || Physics2D.OverlapCircle(transform.position - new Vector3(0f, bottomOffset), collisionDetectorRadius, OtherPlayerLayer);
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

    void RightSideUpPlayer()
    {
        if(rb.velocity.y < 0.1f && rb.velocity.x < 0.5f)
        {
            transform.localRotation = Quaternion.identity;
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
