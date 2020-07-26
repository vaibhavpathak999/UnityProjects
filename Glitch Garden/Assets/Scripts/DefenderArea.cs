using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DefenderArea : MonoBehaviour
{
    Defender defenders;
    GameObject defendersParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defendersParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defendersParent)
        {
            defendersParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }
    
    public void SetSelectedDefender(Defender defenderToSelected)
    {
        defenders = defenderToSelected;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defenders.GetStarCost();
        
        // if we have enough stars / spawn the defender / spend the stars

        if(StarDisplay.HaveEnoughStars(defenderCost))
        {       
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);           
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defenders, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defendersParent.transform;
    }
}
