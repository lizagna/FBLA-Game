using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class MovingPlatformY : MonoBehaviour {

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    /// <summary>
    /// 
    /// </summary>
    void Start() {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
    }

    /// <summary>
    /// 
    /// </summary>
    void Update() {
        Move();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Move() {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);

        if(Vector3.Distance(childTransform.localPosition, nextPos) <= 0.1) {
            ChangePosition();
        }
    }

    private void ChangePosition() {
        nextPos = nextPos != posA ? posA : posB;    //toggles next position between A and B
    }
}
