using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    BoxCollider2D enemyFeet;
    CapsuleCollider2D enemyBody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        enemyFeet = GetComponent<BoxCollider2D>();
        enemyBody = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacingRight())
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        else
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        PlayerKilled();
    }
    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        transform.localScale = new Vector2(-Mathf.Sign(myRigidbody.velocity.x), 1);
    }
    private void PlayerKilled()
    {
        if (!enemyBody.IsTouchingLayers(LayerMask.GetMask("Player"))) { return; }
        FindObjectOfType<Player>().Death();  
    }
}
