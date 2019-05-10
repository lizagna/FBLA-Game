using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// smart object destroyer
/// </summary>
public class DestroyMe : MonoBehaviour {

    public float aliveTime;


	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Awake () {
        Destroy(gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
