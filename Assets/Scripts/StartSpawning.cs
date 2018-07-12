using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawning : MonoBehaviour {

    public ObjectSpawner objectSpawner;
    public Material objectMaterial;
    public bool startSpawn = true;
    public int targetsNumber = 5;

   
    private void Update()
    {
        if (GameManager.Instance.level1Finished)
        {
            startSpawn = true;
           
        }

        
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && startSpawn && !GameManager.Instance.level1Finished && gameObject.tag == "StartButtonLeftRange")  // da ne pokrece vise puta 
        {
            Debug.Log("1 uvjet");
            startSpawn = false;
            GameManager.Instance.numberOfTargets = targetsNumber;
            GameManager.Instance.UpdateTargetsHitText();
            Debug.Log("trigger hit");

            StartCoroutine(objectSpawner.Spawner());
        }
        else if (Input.GetKeyDown(KeyCode.E) && startSpawn && GameManager.Instance.level1Finished && gameObject.tag == "StartButtonLeftRange") // ako player želi ponovno odigrati
        {
            Debug.Log("2 uvjet");
            GameManager.Instance.targetsHit = 0;
            GameManager.Instance.numberOfTargets = targetsNumber;
            GameManager.Instance.UpdateTargetsHitText();
            GameManager.Instance.level1Finished = false;
           
            StartCoroutine(objectSpawner.Spawner());
        }
        else if (Input.GetKeyDown(KeyCode.E) && startSpawn && !GameManager.Instance.level2Finished && gameObject.tag == "StartButtonMiddleRange")
        {
            Debug.Log("3vjet");
            startSpawn = false;
            GameManager.Instance.targetsHit = 0;
            GameManager.Instance.numberOfTargets = targetsNumber;
            GameManager.Instance.UpdateTargetsHitText();
            Debug.Log("trigger hit");

            StartCoroutine(objectSpawner.Spawner());
        }
        else if (Input.GetKeyDown(KeyCode.E) && startSpawn && GameManager.Instance.level2Finished && gameObject.tag == "StartButtonMiddleRange") 
        {
            GameManager.Instance.targetsHit = 0;
            GameManager.Instance.numberOfTargets = targetsNumber;
            GameManager.Instance.UpdateTargetsHitText();
            GameManager.Instance.level2Finished = false;
            
            StartCoroutine(objectSpawner.Spawner());
        }

    }

    
}

