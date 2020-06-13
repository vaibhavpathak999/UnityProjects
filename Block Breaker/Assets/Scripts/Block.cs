using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particleEffectVFX;
    [SerializeField] int maxHits=2;
    [SerializeField] Sprite[] hitSprites;

    // reference intialization
    Level level;
    GameStatus gameStatus;

    //state variables
    [SerializeField] int timesHit=0; //serialized for debug


    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();

        if (tag == "Breakable") // reading the block's tag if it is breakable blocks
        {
            level.CountBreakableBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprites();
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        level.BlockDestroyed();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        gameStatus.GameScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(particleEffectVFX, transform.position, transform.rotation);
        UnityEngine.Object.Destroy(sparkles, 1.0f);
    }
}
