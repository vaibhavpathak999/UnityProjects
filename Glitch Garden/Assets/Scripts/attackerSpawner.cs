
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class attackerSpawner : MonoBehaviour
{
    bool spawnStarted = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 1f;
    [SerializeField] Attacker[] attackerPrefabArray;  // defining an array of Type Attacker
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawnStarted)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttackers();
        }       
    }

    public void StopSpawning()
    {
        spawnStarted = false;
    }


    private void SpawnAttackers()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length); // Getting a random attacker Index number from lenth of myAttackerPrefabArray
        Spawn(attackerPrefabArray[attackerIndex]); // Calling function Spawn with the random prefab.
    }

    private void Spawn(Attacker myAttacker)
    {
        //Spawning new Attacker as Attacker using Instantiate() as Attacker method
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        // Now we need to spawn the enemy and the list should be added to parent spawner gameObject
        newAttacker.transform.parent = transform;
    }
}
