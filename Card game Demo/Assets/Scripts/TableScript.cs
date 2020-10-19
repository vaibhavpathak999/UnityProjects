using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    [SerializeField] float speed = 10F;
    [SerializeField] GameObject player1,player2,player3,player4;
    private void Start()
    {
        SetPlayer1Active();
    }
    public void RotateTable()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -(90), 0), Time.deltaTime * speed);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180, 0), speed * Time.deltaTime);
    }
    public void SetPlayer1Active()
    {
        player1.SetActive(true);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
    }
    public void SetPlayer2Active()
    {
        player1.SetActive(false);
        player2.SetActive(true);
        player3.SetActive(false);
        player4.SetActive(false);
    }
    public void SetPlayer3Active()
    {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(true);
        player4.SetActive(false);
    }
    public void SetPlayer4Active()
    {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(true);
    }
}
