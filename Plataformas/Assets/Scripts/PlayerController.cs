﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public float jumpPower = 6.5f;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;
    private bool movement = true;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }
	
    // Update is called once per frame
    void Update () {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (grounded){
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)){
            if (grounded){
                jump = true;
                doubleJump = true;
            } else if (doubleJump){
                jump = true;
                doubleJump = false;
            }
        }
    }

    void FixedUpdate()
    {
        
        float h = Input.GetAxis("Horizontal");
        if (!movement) h = 0;
        
        rb2d.AddForce(Vector2.right * speed * h);
        
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
        
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded){
            rb2d.velocity = fixedVelocity;
        }

        if (h > 0.1f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } 

        if (h < -0.1f){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (jump){
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
        
    }
}
