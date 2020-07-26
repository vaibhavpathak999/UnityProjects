using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndImmunity : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float immunity = 100f;

    public bool isInfected = false;

    [SerializeField] float immunityReductionRate = -20f; // Immunity damage rate
    [SerializeField] float healthReductionRate = -20f; // Health damage rate

    [SerializeField] Canvas personHealthDisplay; // Canvas

    int totalPeople = 0;

    [SerializeField] Text totalPeopleText;

    private void Start()
    {
        personHealthDisplay = GetComponentInChildren<Canvas>(); 
        personHealthDisplay.enabled = false; // Disabling the health and immunity canvas
        
        totalPeopleText = GetComponent<Text>(); // Getting the text element of TotalPeopleText
    }
    private void Awake()
    {
        AddToTotal();
    }
    private void SubtractFromTotal()
    {
        totalPeople -= 1;
    }

    private void AddToTotal()
    {
        totalPeople += 1;
        UpdateTextTotalPeople();
    }

    private void Update()
    {
        if(isInfected)
        {
            
            personHealthDisplay.enabled = true;

            if(immunity >0 || health >0)
            {
                if(immunity>0)
                {
                    SetImmunity(immunityReductionRate*Time.deltaTime); // Lowering the immunity per second after person is infected
                    GetComponentInChildren<ImmunitySlider>().SetImmunitySlider(immunity); // lowering the immunity slider accordingly
                }
                else
                {
                    SetHealth(healthReductionRate*Time.deltaTime); // Lowering the health per second after person is infected
                    GetComponentInChildren<HealthSlider>().SetHealthSlider(health);   // lowering the health slider accordingly          
                }
            }
            if(health<0)
            {
                //SubtractFromTotal();
                //StartCoroutine(UpdateTextTotalPeople());
                Destroy(gameObject);
            }
        }
        if(!isInfected)
        {
            personHealthDisplay.enabled = false;
        }
    }
    public float GetHealth()
    {
        return health;
    }
    public float GetImmunity()
    {
        return immunity;
    }
    public void SetHealth(float value)
    {
        health += value;
    }
    public void SetImmunity(float value)
    {
        immunity += value;
    }
    public void makePersonInfected()
    {
        isInfected = true;
    }

    IEnumerator UpdateTextTotalPeople()
    {
        totalPeopleText.text = totalPeople.ToString();
        yield return new WaitForSeconds(1f);
    }

    public void ShowHealthDisplay()
    {
        StartCoroutine(ShowHealthDislplayForSeconds());
    }
    IEnumerator ShowHealthDislplayForSeconds()
    {
        personHealthDisplay.enabled = true;
        yield return new WaitForSeconds(3);
        personHealthDisplay.enabled = false;
    }
}
