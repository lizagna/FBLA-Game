using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControler : MonoBehaviour {

    public float fireSpeed;

    Rigidbody2D Projectile;

    // Use this for initialization
    void Awake () {
        // makes the projectile shoot straight
        Projectile = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z > 0)
        Projectile.AddForce(new Vector2(-1,0) * fireSpeed, ForceMode2D.Impulse);
        else Projectile.AddForce(new Vector2(1, 0) * fireSpeed, ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
