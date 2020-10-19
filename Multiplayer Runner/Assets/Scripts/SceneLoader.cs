using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    private string sceneNameToBeLoaded;
    public void LoadScene(string _sceneName)
    {
        sceneNameToBeLoaded = _sceneName;
        StartCoroutine(InitializingSceneLoading());

    }
    IEnumerator InitializingSceneLoading()
    {
        //first we load the loading scene
        yield return SceneManager.LoadSceneAsync("LoadingScene");
        StartCoroutine(LoadActualScene());
        //load the actual scene
    }
    IEnumerator LoadActualScene()
    {
        var asyncSceneLoading = SceneManager.LoadSceneAsync(sceneNameToBeLoaded);

        //this value stops the scene loading until the scene is loaded
        asyncSceneLoading.allowSceneActivation = false;

        while(!asyncSceneLoading.isDone)
        {
            Debug.Log(asyncSceneLoading.progress);
            if(asyncSceneLoading.progress >= 0.9f)
            {
                asyncSceneLoading.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
