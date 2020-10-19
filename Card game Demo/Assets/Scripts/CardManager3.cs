using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager3 : MonoBehaviour
{
    public static CardManager3 instance;

    //[SerializeField] CardDistributor cardDistributor; // from cardManager GameObject
    //[SerializeField] CardAnalyser cardAnalyser; // from cardManager GameObject

    private List<Sprite> cardSprites = new List<Sprite>();
    [SerializeField] private List<Sprite> cardDeckSprites;
    private List<int> spriteNumbers = new List<int>();

    [SerializeField] private GameObject cardHolder, cardPrefab, dummyCardPrefab, parentHolder;
    int k, childCount;
    private CardView selectedCard, nextCard, previousCard;
    private GameObject dummyCardObj;
    public CardView SelectedCard { get => selectedCard; set => selectedCard = value; }

    // Variables for instantiating 3DCard
    private cardDetails CardDetails;
    [SerializeField] GameObject card3DPrefab;
    [SerializeField] GameObject cardOriginatePosition; // position for instantiating card3D
    [SerializeField] Text text;
    private bool isCard3DInstantiated = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Spawning card in shuffle list
    public void SpawnCard(string name)
    {
        GameObject card = Instantiate(cardPrefab);
        card.name = name;
        card.transform.SetParent(cardHolder.transform);
        card.GetComponent<CardView>().SetImage(cardSprites[k-26]);
        card.GetComponent<CardView>().SetRealCardValue(spriteNumbers[k]);
    }

    // Spawning card on table
    public void Spawn3DCard(int value, Sprite cardSprite)
    {
        GameObject card3D = Instantiate(card3DPrefab);
        card3D.transform.position = cardOriginatePosition.transform.position;
        card3D.name = Convert.ToString(value);
        // sending the value of card to the script
        card3D.GetComponent<cardDetails>().SetImage(cardSprite);
        selectedCard.transform.SetParent(null);
        Destroy(selectedCard);
        FindObjectOfType<CardAnalyser>().ThrownCardNumber(value);// no need to remove from list of card sprites
        FindObjectOfType<CardAnalyser>().Set3DCard(card3D);
        isCard3DInstantiated = false;
        
        StartCoroutine(ActivatingPlayer4());
        IEnumerator ActivatingPlayer4()
        {
            yield return new WaitForSeconds(1.5f);
            FindObjectOfType<TableScript>().SetPlayer4Active();
        }
    }
    private void Start()
    {
        // cardAnalyser = GetComponent<CardAnalyser>();
        CardDetails = card3DPrefab.GetComponent<cardDetails>(); // for accessing the cardDetails script
        spriteNumbers = FindObjectOfType<CardDistributor>().GetSpriteNumbers(); // random numbers for cardDeckSprites

        for (int i = 26; i < 39; i++)
        {
            Sprite tempCard;
            tempCard = cardDeckSprites[spriteNumbers[i]];
            cardSprites.Add(tempCard);
        }
        for (int i = 26; i < 39; i++)
        {
            k = i;
            SpawnCard(Convert.ToString(spriteNumbers[i]));
        }
    }
    private int selectedCardIndex;
    public void SetSelectedCard(CardView card)
    {
        selectedCard = card;
        selectedCardIndex = card.transform.GetSiblingIndex();
        selectedCard.transform.SetParent(parentHolder.transform);
        selectedCard.childIndex = selectedCardIndex;
        GetDummyCard().SetActive(true);
        GetDummyCard().transform.SetSiblingIndex(selectedCardIndex);

        childCount = cardHolder.transform.childCount;
        if (selectedCardIndex + 1 < childCount)
        {
            nextCard = cardHolder.transform.GetChild(selectedCardIndex + 1).GetComponent<CardView>();
        }
        if (selectedCardIndex - 1 > 0)
        {
            previousCard = cardHolder.transform.GetChild(selectedCardIndex - 1).GetComponent<CardView>();
        }
    }

    public void ReleaseSelectedCard()
    {
        if (selectedCard != null)
        {
            GetDummyCard().SetActive(false);
            selectedCard.transform.SetParent(cardHolder.transform);
            if (Mathf.Abs(selectedCard.transform.position.y - dummyCardObj.transform.position.y) > 100)
            {
                GetDummyCard().transform.SetParent(parentHolder.transform);
                selectedCard.transform.SetSiblingIndex(selectedCard.childIndex);
            }
            else
            {
                selectedCard.transform.SetSiblingIndex(GetDummyCard().transform.GetSiblingIndex());
                GetDummyCard().transform.SetParent(parentHolder.transform);
            }
            selectedCard = null;
        }
    }

    public void MoveCard(Vector2 mousePosition)
    {
        if (selectedCard)
        {
            SelectedCard.transform.position = mousePosition;
            if (Mathf.Abs(mousePosition.y) > Mathf.Abs(text.transform.position.y) && isCard3DInstantiated == false)
            {
                isCard3DInstantiated = true;
                Debug.Log("Player 3");
                Spawn3DCard(Convert.ToInt32(selectedCard.name), selectedCard.GetComponent<CardView>().GetSprite());
            }
            CheckWithNextCard();
            CheckWithPreviousCard();
        }
    }

    private GameObject GetDummyCard()
    {
        if (dummyCardObj != null)
        {
            if (dummyCardObj.transform.parent != cardHolder.transform)
            {
                dummyCardObj.transform.SetParent(cardHolder.transform);
            }
            return dummyCardObj;
        }
        else
        {
            dummyCardObj = Instantiate(dummyCardPrefab);
            dummyCardObj.name = "DummyCard";
            dummyCardObj.transform.SetParent(cardHolder.transform);
        }
        return dummyCardObj;
    }

    void CheckWithNextCard()
    {
        if (selectedCard)
        {
            if (nextCard != null)
            {
                if (selectedCard.transform.position.x > nextCard.transform.position.x)
                {
                    int index = nextCard.transform.GetSiblingIndex();
                    nextCard.transform.SetSiblingIndex(dummyCardObj.transform.GetSiblingIndex());
                    previousCard = nextCard;
                    if (index + 1 < childCount)
                    {
                        nextCard = cardHolder.transform.GetChild(index + 1).GetComponent<CardView>();
                    }
                    else
                    {
                        nextCard = null;
                    }
                }
            }
        }
    }
    void CheckWithPreviousCard()
    {
        if (selectedCard)
        {
            if (previousCard != null)
            {
                if (selectedCard.transform.position.x < previousCard.transform.position.x)
                {
                    int index = previousCard.transform.GetSiblingIndex();
                    previousCard.transform.SetSiblingIndex(dummyCardObj.transform.GetSiblingIndex());
                    nextCard = previousCard;
                    if (index - 1 >= 0)
                    {
                        previousCard = cardHolder.transform.GetChild(index - 1).GetComponent<CardView>();
                    }
                    else
                    {
                        previousCard = null;
                    }
                }
            }
        }
    }

}
