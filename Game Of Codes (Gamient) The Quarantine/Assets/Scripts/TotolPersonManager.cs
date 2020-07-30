using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotolPersonManager : MonoBehaviour
{
    Text totalPopulation;
    int totalPerson=0;

    void Start()
    {
        totalPopulation = GetComponent<Text>();
        totalPopulation.text = totalPerson.ToString();
    }

    public void AddOnePerson()
    {
        totalPerson += 1;
        totalPopulation.text = totalPerson.ToString();
    }

    public void RemoveOnePerson()
    {
        totalPerson -= 1;
        totalPopulation.text = totalPerson.ToString();
    }

    
}
