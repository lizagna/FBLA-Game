using System.Collections;
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
    float move = 0;

    //walking variables
    Animator anim;
    Rigidbody2D rigBody;
    bool isFacingRight;

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
    
    
    //score variable
    public int diamondScore = 0;
    static int stage = 1;
    
    //audio  variables
    public AudioSource grassFootStep;

    bool questionPanelIsActive;

    /// <summary>
    /// initialize object variables
    /// </summary>
    void Start() {
        anim = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody2D>();
        characterHealth = FindObjectOfType<CharacterHealth>();

        isFacingRight = true;

        //Pops up question when collide with sign
        gameController = FindObjectOfType<GameController>();
        questionPanel.gameObject.SetActive(false);
        gameController.UpdateScore(0);

    }

    /// <summary>
    /// update graphic appearance 
    /// </summary>
    void Update() {
        //check if character is off ground
        if (grounded && Input.GetAxis("Player2Jump") > 0) {       
            grounded = false;
            anim.SetBool("isGrounded", grounded);
            rigBody.AddForce(new Vector2(0, jumpHeight));
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) {
            grassFootStep.Pause();
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
        move = Input.GetAxis("Player2Horizontal");                                       // returns value between -1 and 1
        anim.SetFloat("speed", Mathf.Abs(move));

        rigBody.velocity = new Vector2(move * maxSpeed, rigBody.velocity.y);

        if (move > 0 && !isFacingRight) {
            Flip();
        } else if (move < 0 && isFacingRight) {
            Flip();
        }
    }

    /// <summary>
    /// flips direction character is facing
    /// </summary>
    void Flip() {
        isFacingRight = !isFacingRight;
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
            Time.timeScale = 0f;
            PlayerPrefs.SetString("ActiveCharacter", "RedRidingHood");
            questionPanel.gameObject.SetActive(true);
            gameController.isActive = true;
            gameController.ShowQuestion();
            Destroy(col.gameObject);
        }

        //on moving platform
        else if (col.gameObject.tag == "Ground")
            this.transform.parent = col.transform;

        //encounter spike enemy
        else if (col.gameObject.tag == "Enemy") {
            characterHealth.addDamage(5);
            PlayerPrefs.SetFloat("CharacterHealth", characterHealth.currentHealth);
        }

        //encounter diamond then convert to points
        else if (col.gameObject.tag == "Gem") {
            //diamondScore += (2);
            gameController.UpdateScore(2);
            Destroy(col.gameObject);
        }

        //go through portal and take to next level
        else if (col.gameObject.tag == "Level2Portal") {
            stage++;
            SceneManager.LoadScene("Level3");
            PlayerPrefs.SetInt("Level", 2);
            gameController.SetLevel(2);
            gameController.UpdateScore(0);
        } 
        
        else if (col.gameObject.tag == "Level3Portal") {
            stage++;
            SceneManager.LoadScene("Level2");
            PlayerPrefs.SetInt("Level", 3);
            gameController.SetLevel(3);
            gameController.UpdateScore(0);
        } 
        
        else if (col.gameObject.tag == "GameOver") {
            stage = 1;
            PlayerPrefs.SetInt("Level", 1);
            characterHealth.currentHealth = characterHealth.fullHealth;
            SceneManager.LoadScene("MainMenu");

            //TODO: retrieve high score from playerpref and display
        }

        //plays footstep sound
        else if (col.gameObject.tag == "Grass") {
            if (move != 0) {
                if (!grassFootStep.isPlaying)
                    grassFootStep.Play();
            }
            else
                grassFootStep.Pause();
        }
    }
   
    /// <summary>
    /// ensure game object's state is properly set upon exitting the collission event
    /// </summary>
    /// <param name="col">collided object</param>
    private void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "Ground")
            this.transform.parent = null;
    }
}