using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImmunitySlider : MonoBehaviour
{
    [SerializeField] Slider immunitySlider;
    // Start is called before the first frame update
    void Start()
    {
        immunitySlider = GetComponent<Slider>();
    }

    public void SetImmunitySlider(float immunity)
    {
        immunitySlider.value = immunity;
    }
}
