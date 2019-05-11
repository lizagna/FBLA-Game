using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// keep track of enemy's health
/// </summary>
public class EnemyHealth : MonoBehaviour {

    public float enemyMaxHealth;

    float enemyCurrentHealth;

	// Use this for initialization
	void Start () {
        enemyCurrentHealth = enemyMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// update enemy's health
    /// </summary>
    /// <param name="damage"></param>
    public void addDamage(float damage) {
        enemyCurrentHealth -= damage;
        if (enemyCurrentHealth <= 0) makeDead();
    }

    /// <summary>
    /// destroy enemy object
    /// </summary>
    void makeDead() {
        Destroy(gameObject);
    }
}
