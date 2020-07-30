using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    Text Coins;
    [SerializeField] int totalCoins=50;

    private void Start()
    {
        Coins = GetComponent<Text>();
        Coins.text = totalCoins.ToString();
    }
    public void AddCoinsToTotal(int value)
    {
        totalCoins += value;
        Coins.text = totalCoins.ToString();
    }
    public void SubtractPurchaseCoins(int coins)
    {
        if (totalCoins >= coins)
        {
            totalCoins -= coins;
            Coins.text = totalCoins.ToString();
        }
    }
    public int GetCoins()
    {
        return totalCoins;
    }

}
