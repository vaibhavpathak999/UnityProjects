using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public Image img;
    public int childIndex;
    public int realNumber;
    private void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SetImage(Sprite cardSprite)
    {
        img.sprite = cardSprite;
    }
    public Sprite GetSprite()
    {
        return img.sprite;
    }
    public void SetRealCardValue(int value)
    {
        realNumber = value;
    }
    public int GetRealCardNumber()
    {
        return realNumber;
    }

}
