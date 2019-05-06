using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// keep track of game charecter's health
/// </summary>
public class CharacterHealth : MonoBehaviour {

    static public float fullHealth = 100f;
    static public float currentHealth;

    // Heath bar variables
    public Slider healthSlider;

    /// <summary>
    /// initialization
    /// </summary>
	void Start () {
        currentHealth = fullHealth;

        // Health bar initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// update chareacter's health
    /// </summary>
    /// <param name="damage"> points to be deducted fron current health</param>
    public void addDamage(float damage) {
        if (damage <= 0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        if(currentHealth <= 0) {
            makeDead();
        }
    }

    /// <summary>
    /// game over, character's health falls below recovery points
    /// </summary>
    public void makeDead() {
        //TODO: death animation
        //Application.Quit();
    }
}
