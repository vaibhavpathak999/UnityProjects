using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardDetails : MonoBehaviour
{
    [SerializeField] private Image img;
    private int spriteNumber;
    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void SetImage(Sprite cardSprite)
    {
        img.sprite = cardSprite;
    }
    


}
