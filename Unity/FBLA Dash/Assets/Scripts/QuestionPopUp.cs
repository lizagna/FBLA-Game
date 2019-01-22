using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPopUp : MonoBehaviour {

    //Question pops up upon collision with sign
    public GameObject questionPanel;
    private GameController gameController;

    // Use this for initialization
    void Start() {
        gameController = FindObjectOfType<GameController>();
        questionPanel.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Sign") {
            questionPanel.gameObject.SetActive(true);
            gameController.ShowQuestion();
            Destroy(col.gameObject);
        }
    }

    
	
}
