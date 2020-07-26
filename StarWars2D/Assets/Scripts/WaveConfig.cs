using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [Header("Enemy Details")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    public float moveSpeed = 1f;
    [Header("Enemy Spawning Details")]
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    [SerializeField] int numberOfEnemies = 5;
    

    public GameObject getEnemyPrefab() { return enemyPrefab; }
    public List<Transform> getWayPoints() 
    { var waveWayPoints = new List<Transform>();
      foreach(Transform child in pathPrefab.transform)
            {
            waveWayPoints.Add(child);
            }
        return waveWayPoints;
    }
    public float getSpawnRandomFactor() { return spawnRandomFactor; }
    public float getTimeBetweenSpawn() { return timeBetweenSpawn; }
    public int getNumberOfEnemies() { return numberOfEnemies; }
    public float getMoveSpeed() { return moveSpeed; }

}
