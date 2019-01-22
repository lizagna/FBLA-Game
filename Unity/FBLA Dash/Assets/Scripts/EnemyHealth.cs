using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void addDamage(float damage) {
        enemyCurrentHealth -= damage;
        if (enemyCurrentHealth <= 0) makeDead();
    }

    void makeDead() {
        Destroy(gameObject);
    }
}
