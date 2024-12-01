using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUI : MonoBehaviour
{
    public Text healthText;
    public Text pointsText;
    public Text waveText;
    public Text enemyCountText;

    private int health = 100;
    private int points = 0;
    private int wave = 1;
    private int enemyCount = 10;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        // Update health, points, wave, and enemy count as per game logic
        // This is just an example; you would normally update these based on game events

        if (Input.GetKeyDown(KeyCode.Space)) // Simulate killing an enemy
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        int enemyLevel = 2; // Example: level of the enemy
        points += enemyLevel; // Add points based on enemy level
        enemyCount--;

        if (enemyCount <= 0)
        {
            wave++;
            enemyCount = wave * 10; // Increase enemies in the next wave
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health;
        pointsText.text = "Points: " + points;
        waveText.text = "Wave: " + wave;
        enemyCountText.text = "Enemies: " + enemyCount;
    }
}
