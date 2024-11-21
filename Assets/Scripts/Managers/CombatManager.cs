using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] 
    private EnemySpawner[] enemySpawners;

    public float timer = 0f;
    [SerializeField] 
    private float waveInterval = 5f;

    public int waveNumber = 1;
    public int totalEnemies = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waveInterval)
        {
            StartNextWave();
            timer = 0;
        }
    }

    private void StartNextWave()
    {
        waveNumber++;
        foreach (var spawner in enemySpawners)
        {
            if (spawner != null)
            {
                spawner.isSpawning = true;
                spawner.spawnCountMultiplier = waveNumber;
            }
        }
    }
}
