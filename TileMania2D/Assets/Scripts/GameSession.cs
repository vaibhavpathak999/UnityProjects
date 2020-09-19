using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    private int totalCoins = 0;
    [SerializeField] TextMeshProUGUI totalLives;
    [SerializeField] TextMeshProUGUI totalScore;
    // Start is called before the first frame update
    private void Awake()
    {
        var numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberOfGameSessions > 1)
        { 
            Destroy(gameObject); 
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        totalLives.text = playerLives.ToString();
        totalScore.text = totalCoins.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            playerLives -= 1;
            totalLives.text = playerLives.ToString();
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(PlayerDeathDelay());
            IEnumerator PlayerDeathDelay()
            {
                Time.timeScale = 0.4f;
                yield return new WaitForSeconds(1f);
                Time.timeScale = 1f;
                SceneManager.LoadScene(currentSceneIndex);
            }
            
        }
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }

    public int GetCoins()
    {
        return totalCoins;
    }
    public void IncreaseCoins()
    {
        totalCoins += 100;
        totalScore.text = totalCoins.ToString();
    }
}
