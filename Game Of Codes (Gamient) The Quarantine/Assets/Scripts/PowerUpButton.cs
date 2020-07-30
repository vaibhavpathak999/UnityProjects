using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpButton : MonoBehaviour
{
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] int powerUpPrefabCost = 20;
    CoinManager coinManager;

    private void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
    }

    private void OnMouseDown()
    {
        if(coinManager.GetCoins() >= powerUpPrefabCost)
        {
            Vector3 positionOfClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var newPower = Instantiate(powerUpPrefab, positionOfClick, Quaternion.identity);
            coinManager.SubtractPurchaseCoins(powerUpPrefabCost);
        }
    }

}
