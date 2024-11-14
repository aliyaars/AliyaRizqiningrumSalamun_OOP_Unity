using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int Level;

    void Start()
    {
        // Konfigurasi awal untuk Enemy
        // gameObject.SetActive(false); // Mematikan enemy di awal permainan
    }

    void Update()
    {
        // Logika Enemy dasar dan menambahkan sesuai kebutuhan
    }

    // Coroutine untuk mengaktifkan Enemy setelah penundaan tertentu
    protected IEnumerator EnableAfterDelay(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        gameObject.SetActive(true);
    }
}
