using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject spawnedEnemy;

    [SerializeField] 
    private int minimumKillsToIncreaseSpawnCount = 3;

    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] 
    private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;
    public bool isSpawning = false;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (isSpawning)
            {
                for (int i = 0; i < defaultSpawnCount + (spawnCountMultiplier * multiplierIncreaseCount); i++)
                {
                    Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
                    spawnCount++;
                    yield return new WaitForSeconds(spawnInterval);
                }
            }
            yield return null;
        }
    }

    public void IncrementKillCount()
    {
        totalKill++;
        totalKillWave++;
        if (totalKillWave >= minimumKillsToIncreaseSpawnCount)
        {
            spawnCountMultiplier++;
            totalKillWave = 0;
        }
    }
}
