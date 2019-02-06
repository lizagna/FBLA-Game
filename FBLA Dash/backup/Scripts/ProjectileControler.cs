using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControler : MonoBehaviour {

    public float fireSpeed;

    Rigidbody2D fireProjectile;

    void Awake () {
        // determines direction of fireball
        fireProjectile = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z > 0)
            fireProjectile.AddForce(new Vector2(-1,0) * fireSpeed, ForceMode2D.Impulse);
        else
            fireProjectile.AddForce(new Vector2(1, 0) * fireSpeed, ForceMode2D.Impulse);
    }
	

    // Update is called once per frame
    void Update () {
		
	}
}
