using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    
    private void Start()
    {
        healthText = GetComponent<Text>();
        UpdateHealth(100);
    }

    public void UpdateHealth(int value)
    {
        healthText.text =  value.ToString();
    }

}
