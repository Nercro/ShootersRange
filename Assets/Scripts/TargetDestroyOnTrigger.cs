using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestroyOnTrigger : MonoBehaviour {

    public bool destroyEverything = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger hit");
        if (destroyEverything)
        {
            Destroy(other.gameObject, 0.5f);
            Destroy(gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision hit");
        if (destroyEverything)
        {
            Destroy(other.gameObject, 0.5f);
            Destroy(gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
