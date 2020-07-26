using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 20;
    [SerializeField] int PlayerDamage = 5;
    [SerializeField] GameObject killEnemyExplosion;
    [SerializeField] float timeOfExplosion = 1f;

    public int GetDamage()
    {
        return damage;
    }
    public int PlayerGetDamage()
    {
        return PlayerDamage;

    }

    public void Hit()
    {
        Destroy(gameObject);
    }
    public void ExplodeOnKillEnemy()
    {
        StartCoroutine(FireExplosion());
    }
    IEnumerator FireExplosion()
    {
        killEnemyExplosion =  Instantiate(killEnemyExplosion,transform.position,transform.rotation);
        yield return new WaitForSeconds(timeOfExplosion);
        Destroy(killEnemyExplosion);
    }

}
