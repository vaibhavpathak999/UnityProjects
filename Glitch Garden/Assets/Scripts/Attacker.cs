using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{    
    [Range(0f,5f)] [SerializeField] float currentSpeed = 1f;
    GameObject CurrentTargetAttack;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }
    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            FindObjectOfType<LevelController>().AttackerKilled();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left*currentSpeed*Time.deltaTime);
        GetAnimationState();
    }

    private void GetAnimationState()
    {
        if(!CurrentTargetAttack)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float Speed)
    {
        currentSpeed =  Speed;
    }

    public void Attack(GameObject Target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        CurrentTargetAttack = Target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!CurrentTargetAttack) { return; }
        Health health = CurrentTargetAttack.GetComponent<Health>();
        health.damageOnHit(damage); 
    }

    public void destroyEnemy()
    {
        Destroy(gameObject);
    }

   
}
