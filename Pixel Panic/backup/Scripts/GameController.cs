﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// keep track of game statistic
/// </summary>
public class GameController : MonoBehaviour {

    public Text questionDisplayText;
    public TextMeshProUGUI scoreDisplayText;

    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

    //[SerializeField] 
    public int score;

    private CharacterHealth characterHealth;
    private CharacterController characterController; 
    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
    

    /// <summary>
    /// initialize object variance
    /// </summary>
    void Start() {
        dataController = FindObjectOfType<DataController>();

        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;

        characterHealth = FindObjectOfType<CharacterHealth>();
        characterController = FindObjectOfType<CharacterController>(); 
        score = 0;

        ShowQuestion();
    }

    /// <summary>
    /// ramdomly pick a question from the pool and show
    /// </summary>
    public void ShowQuestion() {
        RemoveAnswerButtons();
        // randomly select question from question pool
        int randomIndex = Random.Range(0, questionPool.Length);
        QuestionData questionData = questionPool[randomIndex];
        questionDisplayText.text = questionData.questionText;
        for (int i = 0; i < questionData.answers.Length; i++) {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObjects.Add(answerButtonGameObject);
            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.SetUp(questionData.answers[i]);
        }
    }

    /// <summary>
    /// clear questionair panel
    /// </summary>
    private void RemoveAnswerButtons() {
        while (answerButtonGameObjects.Count > 0) {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    /// <summary>
    /// examine player's answer
    /// </summary>
    /// <param name="isCorrect">answered status</param>
    public void AnswerButtonClicked(bool isCorrect) {
        if (isCorrect) {
            score += currentRoundData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = (score + characterController.score).ToString();
        } else {
            characterHealth.addDamage(10);
        }

        ExitQuestion();
    }

    /// <summary>
    /// hide the questionair panel
    /// </summary>
    public void ExitQuestion() {
        questionDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }
}
