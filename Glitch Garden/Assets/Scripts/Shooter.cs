using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    GameObject projectileParent;
    attackerSpawner myLaneSpawner;
    Animator animator;
    private void Start()
    {
        SetLaneSpawner();
        CreateProjectileParent();
        animator = GetComponent<Animator>();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if(!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("IsAttacking",true);
            //To change animation from idle to shoot
        }
        else 
        {
            animator.SetBool("IsAttacking", false);
            //to change animation from shooting to idle
        }
    }

    private void SetLaneSpawner()
    {
       attackerSpawner[] spawners = FindObjectsOfType<attackerSpawner>();
        foreach (attackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        // if my lane spawner child count less than equal to 0 return false
        if(myLaneSpawner.transform.childCount <=0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }

}
