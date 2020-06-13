using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameStatus: MonoBehaviour
{
    // game config 
    [Range(0.1f,5f)] [SerializeField] private float gameSpeed = 1f;

    [SerializeField] TextMeshProUGUI scoreText;

    // game params
    [SerializeField] int gameScore = 0;
    [SerializeField] int blockBreakPoints = 100;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }


    private void Start()
    {
        scoreText.text = gameScore.ToString();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void GameScore()
    {
        gameScore += blockBreakPoints;
        scoreText.text = gameScore.ToString();
    }
}
