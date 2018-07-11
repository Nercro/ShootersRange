using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    
    public int scoreValue = 10;
    public float timeValue = 5.0f;
    public int timesHitToDie = 1;
    public bool destroyOther = false;
    public bool destroySelf = false;

    private int _targetHitCount = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile" && destroyOther && destroySelf)
        {
            _targetHitCount++;
            if (_targetHitCount >= timesHitToDie)
            {
                Debug.Log("Target HIT... Destroy Projectile and Object");
                GameManager.Instance.UpdateScore(scoreValue);
                GameManager.Instance.UpdateTime(timeValue);
                GameManager.Instance.TargetsHitControler(1, gameObject.tag);
                
                Destroy(other.gameObject, 0.5f);
                Destroy(gameObject);
                _targetHitCount = 0;
            }

            
        }
        else if (other.gameObject.tag == "Projectile" && !destroyOther && destroySelf)
        {
            Debug.Log("Target HIT... Destroy Object");

            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Projectile" && !destroySelf && destroyOther)
        {
            Debug.Log("Target HIT... Destroy Projectile");

            Destroy(other.gameObject);
        }


    }

    public void TakeDamage()
    {
        _targetHitCount++;
        if (_targetHitCount >= timesHitToDie)
        {
            Debug.Log("Target HIT... Destroy Projectile and Object");
            GameManager.Instance.UpdateScore(scoreValue);
            GameManager.Instance.UpdateTime(timeValue);
            GameManager.Instance.TargetsHitControler(1, gameObject.tag);

            Destroy(gameObject);
            _targetHitCount = 0;
        }
    }
}
