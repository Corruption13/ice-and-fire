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
    public int maxJump = 1;

    private int h = 0;
    private int v = 0;
    private int jumpCount = 1;
    
    private Vector2 overlapBoxSize;


    private void Start()
    {
        overlapBoxSize = new Vector2(2* collisionDetectorRadius, 2*collisionDetectorRadius);
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
        if (jumpCount != maxJump && ValidLayerCheck()) jumpCount = maxJump;

    }

    void FixedUpdate()
    {
        MovePlayerHorizontal(h);
        if(v!=0)
            JumpPlayer(v);
    }

    /* Controls Section 
     * 
     */
    void GetInput()
    {
        v = Input.GetKey(jumpkey) ? 1 : 0;
        h = Input.GetKey(rightkey) ? 1 : Input.GetKey(leftkey) ? -1 : 0;
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


    /* Motion Functions Section 
    * 
    */
    void MovePlayerHorizontal(int horizontal)
    {
        if(horizontal != 0)
            rb.velocity = new Vector2(horizontal * Time.deltaTime * speed, rb.velocity.y);
        if(horizontal == 0)
        {
            if (!Physics2D.OverlapBox(transform.position, overlapBoxSize, 360f, MovableLayer))
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        
    }

    public void JumpPlayer(int v)
    {
        
        
        if (jumpCount > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpforce, 0);
            jumpCount--;
        }

    }

    private bool ValidLayerCheck()
    {
        return Physics2D.OverlapBox(transform.position, overlapBoxSize, 180f, groundlayer) 
                || Physics2D.OverlapCircle(transform.position - new Vector3(0f, bottomOffset), collisionDetectorRadius, MovableLayer)
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
        
        if(rb.velocity == Vector2.zero)
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
