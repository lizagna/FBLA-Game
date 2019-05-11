using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// keep track of game charecter's health
/// </summary>
public class GirlHealth : MonoBehaviour {

    public float fullHealth = 100f;
    public float currentHealth;
    public AudioSource playerHurt;

    // Heath bar variables
    public Slider healthSlider;

    public GameObject gameOverDisplay;

    /// <summary>
    /// initialization
    /// </summary>
	void Start () {
        currentHealth = fullHealth;

        // Health bar initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        gameOverDisplay.SetActive(false);
    }
	

    /// <summary>
    /// update chareacter's health
    /// </summary>
    /// <param name="damage"> points to be deducted fron current health</param>
    public void addDamage(float damage) {
        if (damage <= 0)
            return;

        playerHurt.Play();

        currentHealth -= damage;
        

        healthSlider.value = currentHealth;

        if (currentHealth <= 0) {
            gameOver();
        }
    }
    
    /// <summary>
    /// game over, character's health falls below recovery points
    /// </summary>
    public void gameOver() {
        //Time.timeScale = 0f;
        //gameOverDisplay.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }
}
