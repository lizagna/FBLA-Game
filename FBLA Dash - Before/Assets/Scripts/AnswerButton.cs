using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// answer button control
/// </summary>
public class AnswerButton : MonoBehaviour {

    public TextMeshProUGUI answerText;
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
    /// <param name="data">input data</param>
    public void SetUp(AnswerData data) {
        answerData = data;
        answerText.text = answerData.answerText;
    }

    /// <summary>
    /// handle player's answer choice
    /// </summary>
    public void HandleClick() {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}
