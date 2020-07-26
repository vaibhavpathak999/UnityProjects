using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    int health = 100;


    void Awake()
    {
        SetUpSingleTon();
    }
    private void SetUpSingleTon()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions>1)
        {   
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public int GetHealth()
    {
        return health;
    }
    public void ManageHealth(int healthValue)
    {
        health = healthValue;
    }

}
