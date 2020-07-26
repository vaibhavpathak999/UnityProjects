using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float moveSpeed = 10f;
    float xMin, xMax;
    float yMin, yMax;
    [SerializeField] float xPadding = 1f;
    [SerializeField] float yPadding = 1f;

    [Header("Projectile Laser")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectFiringPeriod = 0.1f;

    [Header("PlayerHealth")]
    [SerializeField] int playerHealth = 100;
    [SerializeField] GameObject explosionPlayerKill;


    [SerializeField] AudioClip playerShoot;
    public AudioClip playerKilled;
    [SerializeField] float Volume=1f;
    [SerializeField] float KVolume = 2f;
    Coroutine fireCoroutine;

    private LevelLoader loadScene;

    [SerializeField] GameObject damageDealer;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        loadScene = FindObjectOfType<LevelLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        AudioSource.PlayClipAtPoint(playerKilled, Camera.main.transform.position,0.5f);
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.PlayerGetDamage();
        if(playerHealth<0)
        {
            playerHealth = 0;
        }
        gameSession.ManageHealth(playerHealth);

        
        damageDealer.Hit();        
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject Explosion = Instantiate(explosionPlayerKill, transform.position, transform.rotation);
        Destroy(Explosion, 2f);
        AudioSource.PlayClipAtPoint(playerKilled, transform.position, KVolume);
        loadScene.LoadGameOver();
    }

    private void Fire()
    { if (Input.GetButtonDown("Fire1"))
        {
          fireCoroutine = StartCoroutine(FireContinuously());
        }
     if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position + new Vector3(0,.8f,0), Quaternion.identity);
            AudioSource.PlayClipAtPoint(playerShoot, Camera.main.transform.position, Volume);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectFiringPeriod);
        }
    }
    
    
    private void Move()
    {

        var deltaY = Input.GetAxis("Vertical")*Time.deltaTime*moveSpeed;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        float newPosX = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newPosY = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newPosX, newPosY);

    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
    }
}
