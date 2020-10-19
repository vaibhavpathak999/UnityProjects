using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCardDectectionScript : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hello");
    }


}
