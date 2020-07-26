using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTree : MonoBehaviour
{
    [SerializeField] int starAmount = 4;

    public void AddStars(int amount)
    {
        var displayScore = FindObjectOfType<StarDisplay>();
        displayScore.AddStars(starAmount);
    }
}


