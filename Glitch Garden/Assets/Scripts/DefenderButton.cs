using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        LabelDefenderWithCost();
    }

    private void LabelDefenderWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if(!costText)
        {
            Debug.LogError(name + " add a cost Text ");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderArea>().SetSelectedDefender(defenderPrefab);
    }
    /* In the above code we enable us to use button as toggle the color. When we press a button it makes it color white and when we press other button
     * its color becomes white and other becomes again black. Awesome 
     * We are using the foreach loop which makes the color black everytime we press the button. And at last we use spriteRenderer to change the color of the 
     * button sprite we want to use. By doing this we are able to make toggle happen. Easy!!!
     */
}
