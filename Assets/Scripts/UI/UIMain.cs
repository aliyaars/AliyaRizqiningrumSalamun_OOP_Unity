using UnityEngine;
using UnityEngine.UIElements;

public class UIMain : MonoBehaviour
{
    private Label pointsLabel;
    private Label healthLabel;
    private Label waveLabel;
    private Label enemiesLabel;

    private Player currentPlayer;
    private CombatManager currentCombatManager;

    void Start()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        pointsLabel = rootVisualElement.Q<Label>("Point");
        healthLabel = rootVisualElement.Q<Label>("Health");
        waveLabel = rootVisualElement.Q<Label>("Wave");
        enemiesLabel = rootVisualElement.Q<Label>("Enemies");

        currentPlayer = Player.Instance;
        currentCombatManager = FindObjectOfType<CombatManager>();
    }

    void Update()
    {
        if (currentPlayer != null && healthLabel != null)
        {
            healthLabel.text = "Health: " + currentPlayer.GetComponent<HealthComponent>().health;
        }

        if (currentCombatManager != null)
        {
            if (pointsLabel != null)
            {
                pointsLabel.text = "Points: " + currentCombatManager.totalPoints;
            }
            if (waveLabel != null)
            {
                waveLabel.text = "Wave: " + currentCombatManager.waveNumber;
            }
            if (enemiesLabel != null)
            {
                enemiesLabel.text = "Enemies Left: " + currentCombatManager.totalEnemies;
            }
        }
    }
}
