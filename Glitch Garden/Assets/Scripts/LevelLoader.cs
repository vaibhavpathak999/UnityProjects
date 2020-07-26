using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    int nextSceneIndex;
    float TimeSeconds = 4f;


    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex ==3)
        {
            nextSceneIndex = 1;
        }
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadingCoroutine());
        }
    }

    IEnumerator LoadingCoroutine()
    {
        yield return new WaitForSeconds(TimeSeconds);
        NextLevelLoader();
    }
    public void NextLevelLoader()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void ApllicationQuit()
    {
        Application.Quit();
    }

    public void SetStartLevel()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadStartLevel());
    }
    IEnumerator LoadStartLevel()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level1");
    }
    public void SetLoseScreen()
    {
        StartCoroutine(LoadLoseScreen());
    }
    public void SetOptionScreen()
    {
        StartCoroutine(LoadOptionScreen());
    }
    IEnumerator LoadOptionScreen()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Option Screen");
    }
    IEnumerator LoadLoseScreen()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Start");
    }


}

