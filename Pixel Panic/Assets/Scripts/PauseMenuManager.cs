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
        pauseMenuDisplay.SetActive(false);
        level1HelpDisplay.SetActive(false);
        level2HelpDisplay.SetActive(false);
        level3HelpDisplay.SetActive(false);
    }

    public void Pause() {
        Time.timeScale = 0f;
        pauseMenuDisplay.SetActive(true);   
    }

    public void Resume() {
        pauseMenuDisplay.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Help() {
        Time.timeScale = 0f;
        int level = PlayerPrefs.GetInt("Level");

        if(level == 1)
            level1HelpDisplay.SetActive(true);

        else if(level == 2)
            level1HelpDisplay.SetActive(true);
        else
            level3HelpDisplay.SetActive(true);
    }

    public void ExitHelp() {
        int level = PlayerPrefs.GetInt("Level");

        if (level == 1)
            level1HelpDisplay.SetActive(false);

        else if (level == 2)
            level1HelpDisplay.SetActive(false);
        else
            level3HelpDisplay.SetActive(false);

        Time.timeScale = 1f;
    }

    /*public void Level1Help() {
        Time.timeScale = 0f;
        level1HelpDisplay.SetActive(true);
        
    }

    public void Level2Help() {
        Time.timeScale = 0f;
        level2HelpDisplay.SetActive(true);
        
    }

    public void Level3Help() {
        Time.timeScale = 0f;
        level3HelpDisplay.SetActive(true);
        
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
    }*/

    public void Options() {
        SceneManager.LoadScene("Options");
    }

    public void PlayAgain() {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void BackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
