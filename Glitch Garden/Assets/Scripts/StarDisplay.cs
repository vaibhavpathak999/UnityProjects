using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;
    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateStars();
    }
    public void UpdateStars()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateStars();
    }
    public void SpendStars(int amount)
    {
        if( stars>=amount)
        {
            stars -= amount;
            UpdateStars();
        }
    }
}
