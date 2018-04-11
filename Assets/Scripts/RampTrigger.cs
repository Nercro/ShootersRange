using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampTrigger : MonoBehaviour {

    public GameObject ramp;
    private bool _spawnText = true;

    private void OnTriggerEnter(Collider other)
    {
        Animator rampAnimation = ramp.GetComponent<Animator>();
        if (other.gameObject.tag == "Player" && gameObject.tag == "RampLeftRange")
        {
            Debug.Log("ramp trigger entered");
            rampAnimation.enabled = true;
            if (_spawnText)
            {
                GameManager.Instance.textState = GameManager.TextStates.RampLeftRange; 
                GameManager.Instance.LoadText();
                _spawnText = false;
            }
            
        }
        else if (GameManager.Instance.level1Finished && other.gameObject.tag == "Player" && gameObject.tag == "RampMiddleRange")
        {
            _spawnText = true;
            Debug.Log("ramp trigger entered");
            rampAnimation.enabled = true;
            if (_spawnText)
            {
                GameManager.Instance.textState = GameManager.TextStates.RampMiddleRange;
                GameManager.Instance.LoadText();
                _spawnText = false;
            }
            
        }
        else if (GameManager.Instance.level2Finished && other.gameObject.tag == "Player" && gameObject.tag == "RampRightRange")
        {
            _spawnText = true;
            Debug.Log("ramp trigger entered");
            rampAnimation.enabled = true;
            if (_spawnText)
            {
                GameManager.Instance.textState = GameManager.TextStates.RampRightRange;
                GameManager.Instance.LoadText();
                _spawnText = false;
            }
        }
    }
}
