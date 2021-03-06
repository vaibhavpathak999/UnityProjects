﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        
        if (nextScene > 3)
        {
            nextScene = 0;
            FindObjectOfType<GameStatus>().ResetGame();
        }
        SceneManager.LoadScene(nextScene);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
