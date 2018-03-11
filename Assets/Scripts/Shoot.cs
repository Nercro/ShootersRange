using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    
    public GameObject projectilePrefab;
    public float power = 10.0f;
    // public List<Transform> firingPoints = new List<Transform>();  za vise firing pointova
    public Transform firingPoint;
    public float rateOfFire = 1;

    

    public enum FiringModes
    {
        Semi,
        Burst,
        Auto,

    }
    public FiringModes firingModeActive = FiringModes.Semi;

    private int _timesFPressed = 0;
    private float _nexFire;

    private void Awake()
    {
        Cursor.visible = false; // miče strelicu mousa u igri
        Cursor.lockState = CursorLockMode.Locked; // zaključa poziciju cursora da ne izlazi iz ekrana bez obzira sto se ne vidi u igri
     
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //for (int i = 0; i < firingPoints.Count; i++)
            //{
            //    ShootProjectile(firingPoints [i]);    za više Firing Pointova
            //}
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SwichFiringMode();
        }

        switch (firingModeActive)
        {
            case FiringModes.Semi:
                GameManager.Instance.fireMode.text = "Fire Mode: Semi";

                if (Input.GetMouseButtonDown(0))
                {
                    ShootProjectile();
                }
                break;

            case FiringModes.Burst:
                GameManager.Instance.fireMode.text = "Fire Mode: Burst";

                if (Input.GetMouseButtonDown(0) && GameManager.Instance.level1Finished)
                {
                    StartCoroutine(BurstFire());
                }
                break;

            case FiringModes.Auto:
                GameManager.Instance.fireMode.text = "Fire Mode: Auto";

                if (Input.GetMouseButton(0) && Time.time > _nexFire)
                {
                    _nexFire = Time.time + rateOfFire;
                        
                    ShootProjectile();
                    //vidjeti za fire rate (najvjerojatnije isto rijesenje sa cekanjem kao u buirstu)
                }
                break;
            default:
                break;
        }
    }

    private IEnumerator BurstFire()
    {
        for (int i = 0; i < 3; i++)
        {
            ShootProjectile();
            yield return new WaitForSeconds(rateOfFire);
        }
    }


    private void ShootProjectile()
    {
        GameObject fireProjectile =  Instantiate(projectilePrefab, firingPoint.position, Quaternion.identity) as GameObject;
        Rigidbody fireProjectileRigidbody = fireProjectile.GetComponent<Rigidbody>();

        fireProjectileRigidbody.AddForce(firingPoint.forward * power, ForceMode.VelocityChange);
        
    }

    public void SwichFiringMode()
    {
        int firingModesLength = System.Enum.GetValues(typeof(FiringModes)).Length;
        firingModeActive++;
        _timesFPressed++;

        if (_timesFPressed >= firingModesLength)
         {
              firingModeActive = FiringModes.Semi;
              _timesFPressed = 0;
         }
    }
}

