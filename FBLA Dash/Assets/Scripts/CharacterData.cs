using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterData : MonoBehaviour {

    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;

    void Start() {
        highScore.text = ( PlayerPrefs.GetInt("DiamondScore", 0) + PlayerPrefs.GetInt("AnswerScore", 0) ).ToString();
    }
}
