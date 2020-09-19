using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private CircleCollider2D myFeetCollider;
    private CapsuleCollider2D myBodyCollider;

    //Config
    [SerializeField] float moveSpeed;
    [SerializeField] float verticalSpeed;
    [SerializeField] float climbSpeed;
    
    //State
    public bool isAlive = true;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myFeetCollider = GetComponent<CircleCollider2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipPlayerSprite();
        Jump();
        Climb();
        SpikeTouched();
    }
    private void Run()
    {
        float horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(horizontalMovement * moveSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }
    private void Jump()
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if(CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 verticalSpeedAddOn = new Vector2(0f, verticalSpeed);
            myRigidbody.velocity += verticalSpeedAddOn;
        }
    }

    private void Climb()
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"))) 
        {
            myRigidbody.gravityScale = 1;
            myAnimator.SetBool("isClimbing", false);
            return;
        }
            myRigidbody.gravityScale = 0;
            float verticalPush = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 verticalVelocity = new Vector2(myRigidbody.velocity.x, verticalPush * climbSpeed);
            myRigidbody.velocity = verticalVelocity;
            bool isPlayerClimbing = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("isClimbing", isPlayerClimbing);
    }

    private void FlipPlayerSprite()
    {
        bool isPlayerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if(isPlayerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1);
        }

        if(isPlayerHasHorizontalSpeed)
        {
            myAnimator.SetBool("isRunning",true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    public void Death()
    { 
            isAlive = false;
            myRigidbody.velocity = new Vector2(0f, 20f);
            myAnimator.SetTrigger("Dying");
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
    public void SpikeTouched()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Spike")))
        {
            Death();
        }
    }
}
