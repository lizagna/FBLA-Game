using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour {
     
    public GameObject pauseMenuDisplay;

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

    public void Options() {
        
    }
}
