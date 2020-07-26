using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damageHealth = 110;
    [SerializeField] float fireSpeed = 2f;

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * fireSpeed);
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attack = otherCollider.GetComponent<Attacker>();
        if (attack && health)
        {
            health.damageOnHit(damageHealth);
            Destroy(gameObject);
        }

    }
}


