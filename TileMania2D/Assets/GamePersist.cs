using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePersist : MonoBehaviour
{
    int startingSceneIndex;

    private void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Awake()
    {
       
        var numberOfGamePersist = FindObjectsOfType<GamePersist>().Length;
        if (numberOfGamePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex != startingSceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
