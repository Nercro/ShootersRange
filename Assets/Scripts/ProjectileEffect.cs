using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEffect : MonoBehaviour {

    public GameObject hitEffectPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
    }
}
