using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {


    public float damage = 1f;
    public float range = 100f;
    public float rateOfFire = 1;

    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffectPrefab;
    public AudioClip shootSound;

    public GameObject zoomCameraPosition;
    

    private GameObject _zoomCameraClone;

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
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked; 
     
    }

    private void Update()
    {
        ZoomCamera();

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
        muzzleFlash.Play();
        AudioSource.PlayClipAtPoint(shootSound, transform.position);

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target)
                target.TakeDamage();

            GameObject impactEffectClone = Instantiate(impactEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactEffectClone, 2f);
        }
        
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
    

    private void ZoomCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            fpsCamera.fieldOfView = 7f;
            zoomCameraPosition.SetActive(true);
        }

        if (Input.GetMouseButtonUp(1))
        {
            fpsCamera.fieldOfView = 60f;
            zoomCameraPosition.SetActive(false);
        }
    }
}

