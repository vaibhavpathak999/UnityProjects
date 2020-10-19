using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class CardAnalyser : MonoBehaviour
{
    private List<int> cardNumbers = new List<int>();
    private List<int> playerScores = new List<int>(new int[] {0,0,0,0});
    private List<int> cardValue = new List<int>();
    private List<char> cardType = new List<char>();
    private List<GameObject> cardsToDelete = new List<GameObject>();
    private int roundWinnerPlayer=0;
    [SerializeField] TextMeshProUGUI roundText;
    private int Player1Score = 0;
    private int Player2Score = 0;
    private int Player3Score = 0;
    private int Player4Score = 0;
    [SerializeField] TextMeshProUGUI P1Score;
    [SerializeField] TextMeshProUGUI P2Score;
    [SerializeField] TextMeshProUGUI P3Score;
    [SerializeField] TextMeshProUGUI P4Score;
    private int roundNumber=1;
    [SerializeField] List<GameObject> playerPositions; //player1Position, player2Position, player3Position, player4Position;

    private void Start()
    {
        roundText.text = roundNumber.ToString();
        P1Score.text = Player1Score.ToString();
        P2Score.text = Player2Score.ToString();
        P3Score.text = Player3Score.ToString();
        P4Score.text = Player4Score.ToString();
    }

    public void ThrownCardNumber(int value)
    {
        cardNumbers.Add(value);
        int cardRealValue = CardValue(value);
        cardValue.Add(cardRealValue);
        char categoryOfCard = CardType(value);
        cardType.Add(categoryOfCard);
        Debug.Log(cardRealValue);
        Debug.Log(categoryOfCard);
       
        if(cardValue.Count ==4)
        {
            for (int i = 0; i < cardValue.Count; i++)
            {
                Debug.Log(cardValue[i]);
            }
            StartCoroutine(winnerProcess());
            IEnumerator winnerProcess()
            {
                Debug.Log("Winner Player");
                roundWinnerPlayer = winnerPlayer();
                Debug.Log(roundWinnerPlayer);
                AllotScores(roundWinnerPlayer);
                yield return new WaitForSeconds(1f);
                MoveCardsToWinner(roundWinnerPlayer);
            }

        }
    }

    private int CardValue(int value) // Method for finding the number of card
    {
        int number = value / 4 + 2;
        return number;
    }
    private char CardType(int value)   //Method for finding the type of card
    {
        char cardType;
        if(value%4==0)
        {
            cardType = 'C';
        }
        else if(value%4==1)
        {
            cardType = 'S';
        }
        else if(value%4==2)
        {
            cardType = 'H';
        }
        else
        {
            cardType = 'D';
        }
        return cardType;
    }
   
 
    public int winnerPlayer()
    {
        char c = cardType[0];
        int largestCardIndex =0;

        for (int i=0; i<4; i++)
        {
            if(cardType[i] =='S')
            {
                cardValue[i] *= 10;
            }
            else if(cardType[i] !='S' && cardType[i] != c)
            {
                cardValue[i] = 0;
            }
        }
        int largestValue = cardValue[0];
        for (int j=0; j<4; j++)
        {
            if (cardValue[j] > largestValue)
            {
                largestCardIndex = j;
                 largestValue = cardValue[j];
            }
        }
        return largestCardIndex;
    }

    //Method for finding the winner of round and adding the points and allowing serial wise throwing card
    private void MoveCardsToWinner(int index)
    {
        GameObject PlayerWon = playerPositions[index];
        /*
        for( int i=0;i<4;i++)
        {
            cardsToDelete[i].GetComponent<Transform>().transform.Translate(PlayerWon.GetComponent<Transform>().transform.position);
        }*/
        StartCoroutine(LetsWaitToMove());
        IEnumerator LetsWaitToMove()
        {
            yield return new WaitForSeconds(1f);
            for (int j = 0; j < 4; j++)
            {
                cardsToDelete[j].SetActive(false);
            }
            cardsToDelete.Clear();
            cardValue.Clear();
            cardType.Clear();
            roundNumber++;
            roundText.text = roundNumber.ToString();
        }
        
    }
    // Method to save cards in a list of gameObjects
    public void Set3DCard(GameObject card)
    {
        cardsToDelete.Add(card);
    }

    public char GetFirstCardType()
    {
        return cardType[0];
    }
    private void UpdateScores()
    {
        P1Score.text = Player1Score.ToString();
        P2Score.text = Player2Score.ToString();
        P3Score.text = Player3Score.ToString();
        P4Score.text = Player4Score.ToString();
    }
    private void AllotScores(int index)
    {
        if(index==0)
        {
            Player1Score++;
        }
        else if(index==1)
        {
            Player2Score++;
        }
        else if(index==2)
        {
            Player3Score++;
        }
        else
        {
            Player4Score++;
        }
        UpdateScores();
    }

}