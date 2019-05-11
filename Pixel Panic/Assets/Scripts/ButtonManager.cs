using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class ButtonManager : MonoBehaviour {

    public GameObject helpDisplay;

    void Start() {
        helpDisplay.SetActive(false);
    }

    public void PlayButton(string newGameLevel) {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("totalScore", 0);
        SceneManager.LoadScene(newGameLevel);
    }

    public void QuitButton() {
        Application.Quit();
    }

    public void InstructionsButton() {
        helpDisplay.SetActive(true);
    }

    public void ExitHelp() {
        helpDisplay.SetActive(false);
    }

    public void Options() {
        SceneManager.LoadScene("Options");
    }

    public void Back() {
        SceneManager.LoadScene("MainMenu");
    }
}
