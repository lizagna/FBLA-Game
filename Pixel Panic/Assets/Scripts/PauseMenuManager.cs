using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {
     
    public GameObject pauseMenuDisplay;
    public GameObject level1HelpDisplay;
    public GameObject level2HelpDisplay;
    public GameObject level3HelpDisplay;


    void Start() {
        pauseMenuDisplay.gameObject.SetActive(false);
    }

    public void Pause() {
        pauseMenuDisplay.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume() {
        pauseMenuDisplay.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Level1Help() {
        level1HelpDisplay.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Level2Help() {
        level2HelpDisplay.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Level3Help() {
        level3HelpDisplay.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Level1Resume() {
        level1HelpDisplay.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Level2Resume() {
        level2HelpDisplay.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Level3Resume() {
        level3HelpDisplay.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Options() {
        SceneManager.LoadScene("Options");
    }

    public void PlayAgain() {
        SceneManager.LoadScene("Level1");
    }

    public void BackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
