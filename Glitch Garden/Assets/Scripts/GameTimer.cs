using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("It is level time in seconds")]
    [SerializeField] float levelTime = 20;
    public bool isLevelFinished=false;
    bool triggeredLevelFinished = false;


    // Update is called once per frame
    private void Update()
    {
        if (triggeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        isLevelFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(isLevelFinished)
        {
            FindObjectOfType<LevelController>().LevelFinished();
            triggeredLevelFinished = true;
        }
    }
}
