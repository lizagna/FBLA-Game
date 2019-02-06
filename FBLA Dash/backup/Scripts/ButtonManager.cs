using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class ButtonManager : MonoBehaviour {

	public void PlayButton(string newGameLevel) {
        SceneManager.LoadScene(newGameLevel);
    }

    public void QuitButton() {
        Application.Quit();
    }

    public void InstructionsButton(string newGameLevel) {
        SceneManager.LoadScene(newGameLevel);
    }

}
