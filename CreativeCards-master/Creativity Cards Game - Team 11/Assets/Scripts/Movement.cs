﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    public Vector2 jump;
    public bool jumped = false;
    public Animator animator;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        animator.SetFloat("MoveSpeed", Mathf.Abs(moveHorizontal));

        transform.position = new Vector2(transform.position.x + moveHorizontal, transform.position.y);

        if ((Input.GetKeyDown(KeyCode.W)) & (!jumped))  //makes player jump
        {
            jumped = true;
            rb.AddForce(jump, ForceMode2D.Impulse);
            //Debug.Log("jumped");
            animator.SetBool("IsJumping", true);
        }

    }
    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jumped = false;
            animator.SetBool("IsJumping", false);
            //Debug.Log("ground hit");
        }

        if (other.gameObject.tag == "Platform")
        {
            jumped = false;
            animator.SetBool("IsJumping", false);
            //Debug.Log("platform hit");
        }

        //Debug.Log("object hit");
    }

    

}