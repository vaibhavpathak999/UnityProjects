using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveAndDrag : MonoBehaviour
{

    float deltaX, deltaY;
    Rigidbody2D rb;
    bool movementAllowed = false;

    public bool isMoving = false;
    public bool waiting = false;
    [SerializeField] float personSpeed = 0.5f;
    [SerializeField] float minXVelocity = -2f;
    [SerializeField] float maxXVelocity = 2f;
    [SerializeField] float minYVelocity = -2f;
    [SerializeField] float maxYVelocity = 2f;
    Vector2 randomPosition;
    [SerializeField] float minDelay = 0.5f;
    [SerializeField] float maxDelay = 1f;
    Vector3 mousePosition;
    Color personColor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        personColor = GetComponent<SpriteRenderer>().color; // getting the color of person sprite
    }

    // Update is called once per frame
    void Update()
    {

        if (waiting == false)
        {
            StartCoroutine(MovePerson());
        }
        else
        {
            //float presentXPosition = transform.position.x;
            //float presentYPosition = transform.position.y;
            //var finalPosition = new Vector2(presentXPosition, presentYPosition) + randomPosition;
            //transform.position = Vector2.Lerp(transform.position, finalPosition, Time.deltaTime * personSpeed); // using lerp method to change the position smoothly
            rb.velocity = new Vector2(Random.Range(minXVelocity,maxXVelocity)*Time.deltaTime*personSpeed, Random.Range(minYVelocity,maxYVelocity) * Time.deltaTime * personSpeed);
        }

        IEnumerator MovePerson()
        {
            //randomPosition = new Vector2(Random.Range(4, -4), Random.Range(4, -4));
            waiting = true;
            yield return new WaitForSeconds(Random.Range(maxDelay, minDelay));
            waiting = false;
        }
        // initializing event touch
  /*      if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            //processing the touch phases
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        movementAllowed = true;
                    } break;

                case TouchPhase.Moved:
                    if(GetComponent<Collider2D>()==Physics2D.OverlapPoint(touchPos) && movementAllowed)
                    {
                        rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    }break;
                
                case TouchPhase.Ended:
                   // GetComponent<SpriteRenderer>().color = personColor; // Setting the color of person back to perivous
                    movementAllowed = false;
                    break;


            }
        }*/
        
    }
}
