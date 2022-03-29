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
        
        h = Input.GetKey(rightkey) ? 1 : h;
        h = Input.GetKey(leftkey) ? -1 : h;
        
        rb.velocity = new Vector3(h * Time.deltaTime * speed, rb.velocity.y, 0);
        RotatePlayer();

    }

    void JumpPlayer()
    {
        v = Input.GetKey(jumpkey) ? 1 : v;
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

    void clampPlayerMovement()
    {
        Vector3 position = transform.position;

        float distance = transform.position.z - Camera.main.transform.position.z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + halfPlayerSizeX;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - halfPlayerSizeX;

        position.x = Mathf.Clamp(position.x, leftBorder, rightBorder);
        transform.position = position;
    }


}
