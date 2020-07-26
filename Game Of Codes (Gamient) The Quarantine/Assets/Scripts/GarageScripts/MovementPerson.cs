using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPerson : MonoBehaviour
{
    public bool isMoving = false;
    public bool waiting = false;
    [SerializeField] float personSpeed = 0.5f;
    Vector2 randomPosition;
    [SerializeField] float minDelay = 0.5f;
    [SerializeField] float maxDelay = 1f;

    //Mouse click positions
    float deltaX, deltaY;
    Vector3 mousePosition;
    Color personColor;

    private void Start()
    {
        personColor = GetComponent<SpriteRenderer>().color; // getting the color of person sprite
    }
    void Update()
    {

        if (waiting == false)
        {
            StartCoroutine(MovePerson());
        }
        else
        { 
            float presentXPosition = transform.position.x;
            float presentYPosition = transform.position.y;
            var finalPosition = new Vector2(presentXPosition,presentYPosition) + randomPosition;
            transform.position = Vector2.Lerp(transform.position,finalPosition, Time.deltaTime * personSpeed); // using lerp method to change the position smoothly
        }


        if ((Input.touchCount) > 0)
        {
            Touch touch = Input.GetTouch(0);
            deltaX = Camera.main.ScreenToWorldPoint(touch.position).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(touch.position).y - transform.position.y;
            GetComponent<SpriteRenderer>().color = Color.black; // changing the color on clicking the person
        }
    }


    IEnumerator MovePerson()
    {
        randomPosition =  new Vector2(Random.Range(4, -4), Random.Range(4, -4));
        waiting = true;
        yield return new  WaitForSeconds(Random.Range(maxDelay,minDelay));
        waiting = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }



    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }

    private void OnMouseUp()
    {
       GetComponent<SpriteRenderer>().color = personColor; // Setting the color of person back to perivous
    }

}
