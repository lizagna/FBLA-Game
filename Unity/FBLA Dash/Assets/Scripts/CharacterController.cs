using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    void Start() {
        //questionPanel.gameObject.SetActive(false);
        anim = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody2D>();

        facingRight = true;
    }

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
            //Instantiate(fire, transform.position, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    void FixedUpdate() {
        //check if we are grounded if no, the we fall
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        anim.SetBool("isGrounded", grounded);

        anim.SetFloat("verticalSpeed", rigBody.velocity.y);

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));

        rigBody.velocity = new Vector2(move * maxSpeed, rigBody.velocity.y);

        if (move > 0 && !facingRight) {
            flip();
        } else if (move < 0 && facingRight) {
            flip();
        }
    }
        void flip() {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        
    // throws fire forwards and reverse
        void throwFire() {
            if(Time.time > nextFire) {
            nextFire = Time.time + fireRate;
                if (facingRight) {
                    Instantiate(fire, fireEject.position, Quaternion.Euler(new Vector3 (0,0,0)));
                } 
                else if (!facingRight) {
                    Instantiate(fire, fireEject.position, Quaternion.Euler(new Vector3 (0,0,180f)));
                }
            }

        }
    
}