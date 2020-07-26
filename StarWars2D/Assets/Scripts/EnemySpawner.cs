using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startWave = 0;
    [SerializeField] float SpeedIncrease = 1f;
    [SerializeField] bool looping = true;
    WaveConfig waveConfig;
    int bossValue=0;

    IEnumerator Start()
    {
        waveConfig = FindObjectOfType<WaveConfig>();
        do
        {
           yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
        
    }
    

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startWave; waveIndex < waveConfigs.Count ; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnEnemiesInWave(currentWave));
        }
    }
    private IEnumerator SpawnEnemiesInWave(WaveConfig waveConfig)
    {
       
        for (int enemyCount = 0; enemyCount <= waveConfig.getNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.getEnemyPrefab(), waveConfig.getWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawn());
        }
    }

}
