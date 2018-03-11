using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour {

    public enum movementDirection
    {
        Horizontal,
        Vertical,
        Custom
    }

    public movementDirection targetDirection = movementDirection.Horizontal;
    public float Magnitude = 0.1f;
    public Vector3 customVector;

    private void Update()
    {

        
        switch (targetDirection) { 
        
        case movementDirection.Horizontal:
            transform.Translate(Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad) * Magnitude);
            break;
        
        case movementDirection.Vertical:
            transform.Translate(Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad) * Magnitude);
            break;

        case movementDirection.Custom:
           transform.Translate(customVector * Mathf.Sin(Time.timeSinceLevelLoad) * Magnitude);
            break;

        }
    }
}   
