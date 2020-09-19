using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonSceneLoader : MonoBehaviour
{
    [SerializeField] float sceneLoadingTime = 0.5f;
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
