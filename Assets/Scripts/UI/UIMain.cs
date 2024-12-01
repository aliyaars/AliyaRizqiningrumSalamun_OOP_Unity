using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMain : MonoBehaviour
{
    private Label point;
    private Label health;
    private Label wave;
    private Label enemies;

    private Player player;
    private CombatManager combatManager;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        point = root.Q<Label>("Point");
        health = root.Q<Label>("Health");
        wave = root.Q<Label>("Wave");
        enemies = root.Q<Label>("Enemies");

        player = Player.Instance;
        combatManager = FindObjectOfType<CombatManager>();
    }

    void Update()
    {
        if (player != null && health != null)
        {
            health.text = "Health: " + player.GetComponent<HealthComponent>().health;
        }

        if (combatManager != null)
        {
            if (point != null)
            {
                point.text = "Points: " + combatManager.totalPoints;
            }
            if (wave != null)
            {
                wave.text = "Wave: " + combatManager.waveNumber;
            }
            if (enemies != null)
            {
                enemies.text = "Enemies Left: " + combatManager.totalEnemies;
            }
        }
    }
}
