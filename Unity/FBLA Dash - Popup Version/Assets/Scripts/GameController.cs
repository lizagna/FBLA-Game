using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text questionDisplayText;

    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

    //private GameObject healthText;
    private PlayerHealth playerHealth = new PlayerHealth();
    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start() {
        dataController = FindObjectOfType<DataController>();

        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;

        //healthText = SceneManager.GetSceneByName("Level1").

        ShowQuestion();
    }

    private void ShowQuestion() {
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

    private void RemoveAnswerButtons() {
        while (answerButtonGameObjects.Count > 0) {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect) {
        if (isCorrect) {
            playerHealth.currentHealth += currentRoundData.healthAddedForCorrectAnswer;
        } else {
            playerHealth.currentHealth -= currentRoundData.healthAddedForCorrectAnswer;
        }
        //SceneManager.GetSceneByName("Level1"); 
        //displayHealth.text = "Health: " + playerHealth.currentHealth.ToString();

        EndRound();

    }

    public void EndRound() {
        //isRoundActive = false;
        //SceneManager.LoadScene("Level1");
        SceneManager.LoadScene("Level1");
        //questionDisplay.SetActive(false);
        //roundEndDisplay.SetActive(true);
    }

    // Update is called once per frame
    void Update() {

    }
}
