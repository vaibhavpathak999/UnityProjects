using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    Vector2 paddleToBallVector;
    [SerializeField] bool hasStarted = false;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
   

    private void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        
    }

    private void Update()
    {   
        if(hasStarted!=true)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush,yPush);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
