using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// control camara movement 
/// </summary>
public class CameraFollow : MonoBehaviour {

    public Transform target; //what camera is following
    public float smoothing; //dampening effect

    Vector3 offset; // distance from player

    float lowY; //lowest point camera can go

    /// <summary>
    /// initialize object variables
    /// </summary>
	void Start () {
        offset = transform.position - target.position; //maintain camera position
        lowY = transform.position.y;
	}

    /// <summary>
    /// set where camera wants to be
    /// </summary>
    void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z); 
	}


}
