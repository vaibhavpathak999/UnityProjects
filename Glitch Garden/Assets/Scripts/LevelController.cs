using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //creating a cache memory
    GameTimer gameTimer;
    //securing the spawners in gameobject using serializefield
    int numberOfAttacker = 0;
    bool levelFinished=false;
    [SerializeField] int timeToWait = 5;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    bool isLost = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    public void AttackerSpawned()
    {
        numberOfAttacker++;
    }
    public void AttackerKilled()
    {
        numberOfAttacker--;
        if(numberOfAttacker<=0 && levelFinished)
        {
            StartCoroutine(WinMessage());
        }
    }

    IEnumerator WinMessage()
    {
        if (isLost==false)
        {
            winLabel.SetActive(true);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(timeToWait);
            FindObjectOfType<LevelLoader>().NextLevelLoader();
        }
    }

    public void ShowLoseMessage()
    {
        isLost = true;
        StartCoroutine(LoseMessage());
    }
    
    IEnumerator LoseMessage()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeToWait);
    }


    public void LevelFinished()
    {
        levelFinished = true;
        StopSpawningAllAttacker();
    }
    /// <summary>
    /// This method below uses array of type attackerSpawner and findobjectsoftype<attackerspawner> then uses foreach loop to call upon
    /// individual spawner to call function stop spawning
    /// </summary>
    private void StopSpawningAllAttacker()
    {
        attackerSpawner[] spawnersArray = FindObjectsOfType<attackerSpawner>();
        foreach(attackerSpawner spawner in spawnersArray)
        {
            spawner.StopSpawning();
        }
    }
}
