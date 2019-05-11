using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this is a questionaires dispenser
/// </summary>
public class QuestionPopUp : MonoBehaviour {

    public GameObject questionPanel;

    GameController gameController;

    /// <summary>
    /// initialize object variable and state
    /// </summary>
    void Start() {
        gameController = FindObjectOfType<GameController>();
        questionPanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// Question pops up upon collision with sign
    /// </summary>
    /// <param name="col">collided object</param>
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Sign") {
            questionPanel.gameObject.SetActive(true);
            gameController.ShowQuestion();
            Destroy(col.gameObject);
        }
    }

}
