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
    public TextMeshProUGUI timeRemainingDisplayText;

    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public int totalScores = 0;
    public bool isActive = false;

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

        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        //timeRemaining = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

        characterHealth = FindObjectOfType<CharacterHealth>();
        characterController = FindObjectOfType<CharacterController>();
        totalScores = PlayerPrefs.GetInt("totalScores"); 

        ShowQuestion();
    }

    /*public void Begin() {
        if (!isCountingDown) {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("tick", 1f);
        }
    }

    private void tick() {
        timeRemaining--;
        if (timeRemaining > 0) {
            Invoke("_tick", 1f);
        } 
        else {
            isCountingDown = false;
        }
    } 

    private IEnumerator UpdateTimer() {
        while (isActive) {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f) {
                characterHealth.addDamage(10);
                ExitQuestion();
            }

            yield return new WaitForSeconds(timerSpeed);
        }

       // return null;
            
    } */

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
        
        /*if(isActive) {
          // StartCoroutine(UpdateTimer());
        } */
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
            totalScores += currentRoundData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = (totalScores).ToString();
            PlayerPrefs.SetInt("totalScores", totalScores);
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
        timeRemaining = 8;
        Time.timeScale = 1f;
    }

    /// <summary>
    /// displays remaining time to answer question
    /// </summary>
    //void UpdateTimeRemainingDisplay() {
        //timeRemainingDisplayText.text = timeRemaining.ToString();
    //}
}