using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// keep track of game statistic
/// </summary>
public class GameController : MonoBehaviour {


    public TextMeshProUGUI questionDisplayText;
    public TextMeshProUGUI scoreDisplayText;
    public TextMeshProUGUI scoreDisplayText1;
    public TextMeshProUGUI scoreDisplayText2;
    public TextMeshProUGUI scoreDisplayText3;
    public TextMeshProUGUI timeRemainingDisplayText;

    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public AudioSource correct;
    public int totalScore = 0;
    public bool isActive = false;
    int gameLevel = 1;

    //bool isCountingDown = false;
    //int duration = 8;
    //int timeRemaining;
    //int timerSpeed = 1;
    CharacterHealth characterHealth;
    CharacterController characterController;
    DataController dataController;
    RoundData currentRoundData;
    QuestionData[] questionPool;
    List<GameObject> answerButtonGameObjects = new List<GameObject>();

    /// <summary>
    /// initialize object variance
    /// </summary>
    void Start() {
        dataController = FindObjectOfType<DataController>();

        correct = GetComponent<AudioSource>();

        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        //timeRemaining = currentRoundData.timeLimitInSeconds;
        //UpdateTimeRemainingDisplay();

        characterHealth = FindObjectOfType<CharacterHealth>();
        characterController = FindObjectOfType<CharacterController>(); 

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
            correct.Play();
            UpdateScore(currentRoundData.pointsAddedForCorrectAnswer);
          //  PlayerPrefs.SetInt("totalScores", totalScore);
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
        isActive = false;
        //timeRemaining = 8;
        Time.timeScale = 1f;
    }

    /// <summary>
    /// adds  diamond score and question score
    /// </summary>
    public void UpdateScore(int score) {
        if (totalScore == 0) {
            totalScore = PlayerPrefs.GetInt("totalScore");
        }

        totalScore += score;
        scoreDisplayText.text = totalScore.ToString();
        PlayerPrefs.SetInt("totalScore", totalScore);
    }

    public void SetLevel(int level) {
        gameLevel = level; 
    }
}