using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [Header("Invincibility Settings")]
    [SerializeField] private int blinkingCount = 7;         // Jumlah blink
    [SerializeField] private float blinkInterval = 0.1f;    // Interval waktu antara blink
    [SerializeField] private Material blinkMaterial;        // Material yang digunakan saat blink

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    public bool isInvincible = false;  // Status invincibility

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;  
    }

    // Method untuk memulai efek blinking
    public void StartInvincibility()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityBlink());
        }
    }

    // Enumerator untuk efek blinking 
    private IEnumerator InvincibilityBlink()
    {
        isInvincible = true;
        int blinkCounter = 0;

        while (blinkCounter < blinkingCount)
        {
            // Mengubah material ke blinkMaterial
            spriteRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(blinkInterval);

            // Mengembalikan material ke originalMaterial
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(blinkInterval);

            blinkCounter++;
        }

        // Setelah blinking selesai, kembalikan ke material asli dan status invincible jadi false
        spriteRenderer.material = originalMaterial;
        isInvincible = false;
    }
}
