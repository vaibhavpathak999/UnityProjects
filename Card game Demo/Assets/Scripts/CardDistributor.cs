using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDistributor : MonoBehaviour
{
    private int totalNumberOfCards = 52;
    [SerializeField] public List<Sprite> cardDeckSprites;
    private List<int> cardNumbers = new List<int>();


    private void Awake()
    {
        ShuffledCardDeck();
    }
    public void ShuffledCardDeck()
    {
        List<int> Numbers = new List<int>();
        for(int i=0; i<totalNumberOfCards; i++)
        {
            Numbers.Add(i);
        }
        for(int i=0; i<totalNumberOfCards;i++)
        {
            int randomIndex = Random.Range(0, Numbers.Count -1);
            cardNumbers.Add(Numbers[randomIndex]);
            Numbers.RemoveAt(randomIndex);
        }
    }
   
    public List<int> GetSpriteNumbers()
    {
        return cardNumbers;
    }
}
