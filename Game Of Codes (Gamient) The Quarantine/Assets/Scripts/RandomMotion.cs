using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomMotion : MonoBehaviour
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
    [SerializeField] float minDelay = 0.5f;
    [SerializeField] float maxDelay = 1f;
    Color personColor;


 //The below handles the motion 
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waiting == false)
        {
            StartCoroutine(MovePerson());
        }
        // the code below shows handles the UI elements for showing for 3 seconds on tapping the person
          
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchCoordinates = Camera.main.ScreenToWorldPoint(touch.position);
            touchCoordinates.z = 0;
            if(touchCoordinates.x <= transform.position.x + 1 && touchCoordinates.x >= transform.position.x - 1
                && touchCoordinates.y <= transform.position.y + 1 && touchCoordinates.y >= transform.position.y - 1) // logic needs improvement
            {
                GetComponent<HealthAndImmunity>().ShowHealthDisplay(); // Using ShowHealthFunction from Health and Immunity script to show health and immunity using coroutine
            }          
        }
       


    }
    IEnumerator MovePerson()
    {
        rb.velocity = new Vector2(Random.Range(minXVelocity,maxXVelocity) * Time.deltaTime * personSpeed, Random.Range(minYVelocity,maxYVelocity) * Time.deltaTime * personSpeed);
        waiting = true;
        yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
        waiting = false;
    }

    // This code below manages the Infection spread 
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.GetComponent<HealthAndImmunity>())
        {
            if(GetComponent<HealthAndImmunity>().isInfected) // check if the person is infected or not since it will infect the others
            {
                otherCollider.GetComponent<HealthAndImmunity>().makePersonInfected();
            }
        }

    }
}
