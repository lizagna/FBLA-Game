using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class ButtonManager : MonoBehaviour {

	public void PlayButton() {

        PlayerPrefs.SetInt("totalScore", 0);
        SceneManager.LoadScene("Level1"); 
    }

    public void QuitButton() {
        Application.Quit();
    }

    public void InstructionsButton(string newGameLevel) {
        SceneManager.LoadScene(newGameLevel);
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
