using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformX : MonoBehaviour {

    public float min;
    public float max;
    public float movingSpeed;

    private bool isMovingRight;

    void Update() {
        if (transform.position.x > max)
            isMovingRight = false;

        if (transform.position.x < min)
            isMovingRight = true;

        if (isMovingRight)
            transform.position = new Vector2(transform.position.x + movingSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - movingSpeed * Time.deltaTime, transform.position.y);
    }

}
