using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public StartSpawning startSpawning;
    public Color gizmosColor = Color.white;
    public List<GameObject> objectPrefabs = new List<GameObject>();
    public Vector2 XRange;
    public Vector2 YRange;
    public Vector2 ZRange;
    public float spawnInterval;
    
    public Vector3 gizmoSize;

   
    public IEnumerator Spawner()
    {
        Debug.Log("corutine entered");
        while (startSpawning.targetsNumber > GameManager.Instance.targetsHit)
        {
            SpawnObject();

            yield return new WaitForSeconds(spawnInterval);
        }
        
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = Vector3.zero;
        spawnPosition.x = Random.Range(XRange.x, XRange.y);
        spawnPosition.y = Random.Range(YRange.x, YRange.y);
        spawnPosition.z = Random.Range(ZRange.x, ZRange.y);

        int randomIndex = Random.Range(0, objectPrefabs.Count);
        GameObject objectClone = Instantiate(objectPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        objectClone.transform.parent = transform;
       
    }

    private void OnDrawGizmos()
    {
        Vector3 gizmosCenter = transform.position;
        Vector3 gizmosSize = gizmoSize;
        
        Gizmos.color = gizmosColor;
        Gizmos.DrawWireCube(gizmosCenter, gizmosSize);
    }

    
}
