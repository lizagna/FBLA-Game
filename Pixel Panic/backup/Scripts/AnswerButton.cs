using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class AnswerButton : MonoBehaviour {

    public Text answerText;
    private AnswerData answerData;
    private GameController gameController;

      /// <summary>
    /// initialization
    /// </summary>
    void Start() {
        gameController = FindObjectOfType<GameController>();
    }

    /// <summary>
    /// setup answer data 
    /// </summary>
    /// <param name="data"></param>
    public void SetUp(AnswerData data) {
        answerData = data;
        answerText.text = answerData.answerText;
    }

    /// <summary>
    /// examine player's answer choice
    /// </summary>
    public void HandleClick() {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}
