using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCoinGenerator : MonoBehaviour
{
    [SerializeField] int coinsToBeAdded = 5;

    public void AddCoins()
    {
        FindObjectOfType<CoinManager>().AddCoinsToTotal(coinsToBeAdded);
    }
    
}
