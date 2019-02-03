using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitQuestion : MonoBehaviour {

    public GameObject questionPanel;

    public void ButtonClicked(bool isCorrect) {
        questionPanel.gameObject.SetActive(false);

    }
}
