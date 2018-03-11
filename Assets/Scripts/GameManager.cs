using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public RestartLevelText restartLevelTextPrefab;
    public GameObject level1GuidePrefab;
    public GameObject level1WinTextPrefab;
    public GameObject level2GuidePrefab;
    public GameObject level2WinTextPrefab;
    public GameObject level3GuidePrefab;
    public int Score = 0;
    public float Timer = 30.0f;
    public int scoreToAchive = 50;
    public int numberOfTargets = 0;
    public int targetsHit = 0;
    public Text scoreText;
    public Text timeText;
    public Text targetsHitText;
    public Text fireMode;

    public bool isGameOVer = false;
    public bool level1Finished = false;
    public bool level2Finished = false;

    //singeltone provjeriti
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!isGameOVer)
        {
            UpdateTime(-Time.deltaTime);
        }

    }

    public void UpdateScore(int amount)
    {
        Score += amount;
        scoreText.text = "Score: " + Score.ToString();
    }

    public void UpdateTime(float amount)
    {
        Timer += amount;

        if (Timer <= 0.0f)
        {

            Timer = 0.0f;
            isGameOVer = true;
            Instantiate(restartLevelTextPrefab);
            Debug.Log("Game Over");
        }

        timeText.text = "Time: " + Timer.ToString("F");
    }

    public void UpdateTargetsHitText()
    {
        targetsHitText.text = "Targets: " + targetsHit + "/" + numberOfTargets;
    }

    public void LevelContorl(string enemytag)
    {
        if (targetsHit >= numberOfTargets && enemytag == "Enemy")
        {
            GameManager.Instance.level1Finished = true;
            LoadText("level1Finished");
        }
        else if (targetsHit >= numberOfTargets && enemytag == "EnemyMovable")
        {
            GameManager.Instance.level2Finished = true;
            LoadText("level2Finished");
        }
    }

    public void TargetsHitControler(int amount, string enemyTag)
    {
        if (enemyTag == "Enemy")
        {
            targetsHit += amount;
            UpdateTargetsHitText();
            LevelContorl(enemyTag);
        }
        else if (enemyTag == "EnemyMovable")
        {
            targetsHit += amount;
            UpdateTargetsHitText();
            LevelContorl(enemyTag);
        }
    }

    public void LoadText(string tag)
    {
        switch (tag)
        {
           case "RampLeftRange":
                Instantiate(level1GuidePrefab, level1GuidePrefab.transform.position, Quaternion.identity);
                break;

           case "RampMiddleRange":
                Instantiate(level2GuidePrefab, level2GuidePrefab.transform.position, Quaternion.identity);
                break;

           case "level1Finished":
                Instantiate(level1WinTextPrefab, level1WinTextPrefab.transform.position, Quaternion.identity);
                break;

           case "level2Finished":
                Instantiate(level2WinTextPrefab, level2WinTextPrefab.transform.position, Quaternion.identity);
                break;

           case "RampRightRange":
                Instantiate(level3GuidePrefab, level3GuidePrefab.transform.position, Quaternion.identity);
               break;

           default:
                break;
        }
    }
}
