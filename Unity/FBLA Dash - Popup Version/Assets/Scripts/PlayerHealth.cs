using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float fullHealth;

    public float currentHealth;

    CharacterController controlMovement;

    // Heath bar variables
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;
        controlMovement = GetComponent<CharacterController>();

        // Health bar initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage) {
        if (damage <= 0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0) {
            makeDead();
        }
    }

    public void makeDead() {
        Application.Quit();
    }
}
