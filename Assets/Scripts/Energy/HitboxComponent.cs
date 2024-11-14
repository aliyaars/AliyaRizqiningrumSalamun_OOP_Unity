using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    public HealthComponent healthComponent;  

    void Start()
    {
        if (healthComponent == null)
        {
            // Mengambil HealthComponent dari GameObject ini
            healthComponent = GetComponent<HealthComponent>();  
        }
    }

    // Method untuk menerima damage
    public void Damage(int damage)
    {
        if (!GetComponent<InvincibilityComponent>().isInvincible)
        {
            // // Hanya kurangi health jika tidak invincible
            healthComponent.Subtract(damage);  
        }
    }

    // Method overloading untuk menerima damage dari Bullet
    public void Damage(Bullet bullet)
    {
        if (!GetComponent<InvincibilityComponent>().isInvincible)
        {
            // Mengurangi health berdasarkan damage dari Bullet
            healthComponent.Subtract(bullet.damage);  
        }
    }
}
