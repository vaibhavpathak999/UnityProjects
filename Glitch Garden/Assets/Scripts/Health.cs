using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int attackerHealth = 100;
    [SerializeField] GameObject particle_Effect_On_Kill;

    public void damageOnHit(int damage)
    {
        attackerHealth -= damage;
        if (attackerHealth <= 0)
        {
            TriggerVFX();
            Destroy(gameObject);
        }
    }
    private void TriggerVFX()
    {   if(!particle_Effect_On_Kill)
        {
            return;
        }
       GameObject deathVFX =  Instantiate(particle_Effect_On_Kill, transform.position, transform.rotation);
       Destroy(deathVFX, 1f);
    }

}
