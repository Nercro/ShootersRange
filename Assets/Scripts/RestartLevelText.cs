using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevelText : MonoBehaviour {
    

    private void OnTriggerEnter(Collider other)
    {
       
            Debug.Log("restratr");
            Application.LoadLevel(Application.loadedLevel);
        
    }
    
}  
