using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTargetMove : MonoBehaviour {

    public Vector3 targetMoveDirection;
    public float targetMoveSpeed;

	
	void Update () {

        transform.position += targetMoveDirection * targetMoveSpeed * Time.deltaTime;
	}
}
