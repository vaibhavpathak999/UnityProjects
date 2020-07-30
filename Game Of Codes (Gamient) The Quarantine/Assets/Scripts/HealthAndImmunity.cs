using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndImmunity : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] float immunity = 100f;

    public bool isInfected = false;

    [SerializeField] float immunityReductionRate = -20f; // Immunity damage rate
    [SerializeField] float healthReductionRate = -20f; // Health damage rate

    [SerializeField] Canvas personHealthDisplay; // Canvas

    [SerializeField] Text totalPeopleText;

    [SerializeField] GameObject TheQuarantine; // Quarantine Prefab

    private void Start()
    {
        personHealthDisplay = GetComponentInChildren<Canvas>(); 
        personHealthDisplay.enabled = false; // Disabling the health and immunity canvas
        //FindObjectOfType<TotolPersonManager>().AddOnePerson();
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
                //FindObjectOfType<TotolPersonManager>().RemoveOnePerson();
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

    // below code is for implementing the Quarantine power up
    public void QuarantineEffect()
    {
        GetComponent<RandomMotion>().personSpeed = 0;
        isInfected = false;
        StartCoroutine(InstantiatingQuarantine());
        StartCoroutine(WaitingForQuarantineEffect());
    }
    IEnumerator WaitingForQuarantineEffect()
    {
        yield return new WaitForSeconds(10);
        GetComponent<Collider2D>().isTrigger = false;
        GetComponent<RandomMotion>().personSpeed = 20;
    }
    IEnumerator InstantiatingQuarantine()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(TheQuarantine, GetComponent<Transform>().position, Quaternion.identity);
    }
}
