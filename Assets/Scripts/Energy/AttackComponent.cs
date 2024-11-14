using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    public Bullet bullet;  // Bullet yang digunakan untuk serangan
    public int damage;     // Damage yang diberikan oleh serangan

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jika objek bertabrakan dengan musuh
        if (other.CompareTag("Enemy"))
        {
            // Mengecek apakah Enemy memiliki InvincibilityComponent
            InvincibilityComponent invincibility = other.GetComponent<InvincibilityComponent>();
            if (invincibility != null && !invincibility.isInvincible)
            {
                // Memulai invincibility jika belum aktif
                invincibility.StartInvincibility();
                // Melakukan damage jika musuh tidak invincible
                HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
                if (hitbox != null)
                {
                    // Memberikan damage ke musuh
                    hitbox.Damage(damage);  
                }
            }
        }
    }
}
