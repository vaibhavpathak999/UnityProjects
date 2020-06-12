using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakabeBlocks = 0;

    SceneLoader sceneLoader; // Cache Reference

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }


    public void CountBreakableBlocks()
    {
        breakabeBlocks++;
    }
    public void BlockDestroyed()
    {
        breakabeBlocks--;
        if(breakabeBlocks<=0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
