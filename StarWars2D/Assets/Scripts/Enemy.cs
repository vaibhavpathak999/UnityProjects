using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenCounts = 0.3f;
    [SerializeField] float maxTimeBetweenCounts = 3f;

    [SerializeField] GameObject projectileLaser;
    [SerializeField] float verticalLaserSpeed = -10f;
   

    [SerializeField] AudioClip enemyShoot;
    [SerializeField] AudioClip enemyKilled;
    [SerializeField] float VolumeShoot=.8f;
    [SerializeField] float VolumeKilled = 1f;
    [SerializeField] int scoreKill = 100;

    [SerializeField] GameObject explosionPlayerKill;
    GameSession gameSession;

    private void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenCounts, maxTimeBetweenCounts);
        gameSession = FindObjectOfType<GameSession>();
    }
    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenCounts, maxTimeBetweenCounts);
        }
    }

    private void Fire()
    {
        GameObject FireLaser = Instantiate(projectileLaser, transform.position + new Vector3(0, -.3f, 0), Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(enemyKilled, Camera.main.transform.position, VolumeShoot);
        FireLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-verticalLaserSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        ProcessHit(damageDealer, collision.gameObject.name);
    }

    private void ProcessHit(DamageDealer damageDealer, String objectcollide)
    {
        if (objectcollide != "Player")
        {
            health -= damageDealer.GetDamage();
            if (health <= 0)
            {
                gameSession.AddToScore(scoreKill);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(enemyKilled, Camera.main.transform.position, VolumeKilled * 2);
                damageDealer.ExplodeOnKillEnemy();
            }
        }
        else
        {
            damageDealer.Hit();
            AudioSource.PlayClipAtPoint(enemyKilled, Camera.main.transform.position, VolumeKilled * 5);
            Instantiate(explosionPlayerKill, transform.position, transform.rotation);
            FindObjectOfType<LevelLoader>().LoadGameOver();
        }  
    }
}
