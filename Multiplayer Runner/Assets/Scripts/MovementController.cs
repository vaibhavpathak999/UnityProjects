using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Joystick joystick;
    public int playerSpeed = 15;
    private Vector3 velocityVector = Vector3.zero;
    private Rigidbody rb;
    public float maxVelocityChange = 20;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float xMovement = joystick.Horizontal;
        float zMovement = joystick.Vertical;
        // taking input from joystick every movement

        Vector3 movementHorizontal = transform.right * xMovement;
        Vector3 movementVertical = transform.forward * zMovement*5;

        Vector3 movementVelocityVector = (movementHorizontal + movementVertical).normalized * playerSpeed;

        MovePlayer(movementVelocityVector);
    }

    private void MovePlayer(Vector3 velocity)
    {
        velocityVector = velocity;
    }

    private void FixedUpdate()
    {
        if(velocityVector!=Vector3.zero)
        {
            // finding the change in the velocity
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (velocityVector - velocity);

            //clamping the velocity between maximum and minimum
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0f;

            // applying the force
            rb.AddForce(velocityChange, ForceMode.Acceleration);
        }
    }

}

