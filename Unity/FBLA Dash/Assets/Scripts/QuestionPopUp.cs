using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPopUp : MonoBehaviour {
    
    public GameObject questionPanel;
    //public GameObject explosionEffect;
    //public Transform explosionLocation;

    GameController gameController;

    //Question pops up upon collision with sign
    void Start() {
        gameController = FindObjectOfType<GameController>();
        questionPanel.gameObject.SetActive(false);

    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Sign") {
            questionPanel.gameObject.SetActive(true);
            gameController.ShowQuestion();
            //Instantiate(explosionEffect, explosionLocation.position, transform.rotation = Quaternion.identity);
            Destroy(col.gameObject);  
        }
    }

}
