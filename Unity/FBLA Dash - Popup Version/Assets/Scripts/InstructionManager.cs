using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionManager : MonoBehaviour {

    public void BackToMain(string newGameLevel) {
        SceneManager.LoadScene(newGameLevel);
    }

}