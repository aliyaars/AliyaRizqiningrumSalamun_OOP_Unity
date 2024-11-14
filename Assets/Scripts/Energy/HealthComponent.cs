using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;  // Kesehatan maksimum
    private int health;

    // Getter untuk kesehatan
    public int Health
    {
        get { return health; }
    }

    // Setter untuk mengurangi kesehatan
    public void Subtract(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Menghancurkan objek jika kesehatan <= 0
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // // Set kesehatan awal sama dengan maxHealth
        health = maxHealth;  
    }
}
