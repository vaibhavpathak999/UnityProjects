using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthandLoser : MonoBehaviour
{
    int Health = 100;
    bool messageDislplayed=false;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Attacker>())
        {
            Health -= 10 + (int)(10 *PlayerPrefsController.GetMasterDifficulty());
            collider.GetComponent<Attacker>().destroyEnemy();
            if (!messageDislplayed)
            {
                if (Health < 0)
                {
                    messageDislplayed = true;
                    StartCoroutine(Loser());
                    Health = 0;
                }
                FindObjectOfType<HealthDisplay>().UpdateHealth(Health);
            }
        }

    }

    private IEnumerator Loser()
    {
        FindObjectOfType<LevelController>().ShowLoseMessage();
        yield return new WaitForSeconds(5);
        FindObjectOfType<LevelLoader>().SetLoseScreen();
    }
}
