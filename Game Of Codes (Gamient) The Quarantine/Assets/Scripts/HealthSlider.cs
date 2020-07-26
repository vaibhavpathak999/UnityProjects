using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{

    [SerializeField] Slider healthSlider;

    private void Start()
    {
        healthSlider = GetComponent<Slider>();
    }
    
    public void SetHealthSlider(float health)
    {
        healthSlider.value = health;
    }
}
