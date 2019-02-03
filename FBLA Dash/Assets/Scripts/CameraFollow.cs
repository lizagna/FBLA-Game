using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target; //what camera is following
    public float smoothing; //dampening effect

    Vector3 offset; // distance from player

    float lowY; //lowest point camera can go

	void Start () {
        offset = transform.position - target.position; //maintain camera position
        lowY = transform.position.y;
	}

    //where camera wants to be
    void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z); 
	}


}
