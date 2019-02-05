using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float minX;
    public float maxX;

    private float dirX, movingSpeed = 3f;
    private bool isMovingRight;

    void Update() {
        if (transform.position.x > maxX)
            isMovingRight = false;

        if (transform.position.x < minX)
            isMovingRight = true;

        if (isMovingRight)
            transform.position = new Vector2(transform.position.x + movingSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - movingSpeed * Time.deltaTime, transform.position.y);
    }

}
