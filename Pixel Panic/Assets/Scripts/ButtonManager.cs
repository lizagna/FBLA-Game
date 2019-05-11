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

    public void PlayButton() {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("totalScore", 0);
        SceneManager.LoadScene("Level1");
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

    public void PlayAgain() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
}
