using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {

    static public float fullHealth = 100f;
    static public float currentHealth;


    // Heath bar variables
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;

        // Health bar initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage) {
        if (damage <= 0)
            return;

        currentHealth -= damage;

        healthSlider.value = currentHealth;

        if (currentHealth <= 0) {
            makeDead();
        }
    }

    public void makeDead() {
        //TODO death animation uwu
        //Application.Quit();
    }
}
