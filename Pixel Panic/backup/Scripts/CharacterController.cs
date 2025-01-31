﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// control and orchestrate game character's behaviors
/// </summary>
public class CharacterController : MonoBehaviour {
   
    //movement variables
    public float maxSpeed;

    //walking variables
    Animator anim;
    Rigidbody2D rigBody;
    bool facingRight;

    // for shooting
    public Transform fireEject;
    public GameObject fire;
    float fireRate = 0.5f;
    float nextFire = 0f;

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    //question pop up variables
    public GameObject questionPanel;
    GameController gameController;

    CharacterHealth characterHealth;

    //[SerializeField]
    public int score;

    /// <summary>
    /// initialize object variables
    /// </summary>
    void Start() {
        anim = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody2D>();
        characterHealth = FindObjectOfType<CharacterHealth>();

        facingRight = true;

        //Pops up question when collide with sign
        gameController = FindObjectOfType<GameController>();
        questionPanel.gameObject.SetActive(false);
    }
 
    /// <summary>
    /// update graphic appearance 
    /// </summary>
    void Update() {
        //check if character is off ground
        if (grounded && Input.GetAxis("Jump") > 0) { 
            grounded = false;
            anim.SetBool("isGrounded", grounded);
            rigBody.AddForce(new Vector2(0, jumpHeight));
        }

        // player shooting
        if (Input.GetAxisRaw("Fire1") > 0) {
            throwFire();
        }

        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    /// <summary>
    /// update physical movements
    /// </summary>
    void FixedUpdate() {
        //check if we are grounded if no, the we fall
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        anim.SetBool("isGrounded", grounded);

        anim.SetFloat("verticalSpeed", rigBody.velocity.y);

        //character movement
        float move = Input.GetAxis("Horizontal");                                       // returns value between -1 and 1
        anim.SetFloat("speed", Mathf.Abs(move));

        rigBody.velocity = new Vector2(move * maxSpeed, rigBody.velocity.y);

        if (move > 0 && !facingRight) {
            flip();
        } else if (move < 0 && facingRight) {
            flip();
        }

    }

    /// <summary>
    /// flips direction character is facing
    /// </summary>
    void flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    /// <summary>
    /// set the expected game behavior depending on the collided object
    /// </summary>
    /// <param name="col">collided object</param>
    private void OnCollisionEnter2D(Collision2D col) {
        //question pop up
        if (col.gameObject.tag == "Sign") {
            questionPanel.gameObject.SetActive(true);
            gameController.ShowQuestion();
            Destroy(col.gameObject);
        }

        //on moving platform
        if (col.gameObject.tag == "Ground")
            this.transform.parent = col.transform;

        //encounter spike enemy
        if (col.gameObject.tag == "Enemy")
            characterHealth.addDamage(5);

        //encounter diamond then convert to points
        if (col.gameObject.tag == "Diamond") {
            score += 2;
            gameController.scoreDisplayText.text = (score + gameController.score).ToString();
            Destroy(col.gameObject);
        }

        //go through portal and take to next level
        if (col.gameObject.tag == "PortalToLevel2")
            SceneManager.LoadScene("Level2");
    }

    /// <summary>
    /// ensure game object's state is properly set upon exitting the collission event
    /// </summary>
    /// <param name="col">collided object</param>
    private void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "Ground")
            this.transform.parent = null;
    }

    /// <summary>
    /// throws fire forwards and reverse depending on the current direction facing.
    /// </summary>
    void throwFire() {
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            if (facingRight) {
                Instantiate(fire, fireEject.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            } else if (!facingRight) {
                Instantiate(fire, fireEject.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }

    }
}