using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; 
    private Weapon weapon; 

    // Membuat weaponHolder menjadi weapon yang akan diambil oleh player
    private void Awake()
    {
        if (weaponHolder != null)
        {
            weapon = Instantiate(weaponHolder, transform.position, Quaternion.identity);
            weapon.transform.SetParent(transform); 
            weapon.gameObject.SetActive(false); 
        }
    }

    // Mengatur visual dari weapon saat start
    private void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false); 
            weapon.gameObject.SetActive(false); 
        }
    }

    // Memeriksa tabrakan dengan player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Weapon playerWeapon = other.gameObject.GetComponentInChildren<Weapon>();

            if (playerWeapon != null)
            {
                playerWeapon.transform.SetParent(transform, false);
                playerWeapon.transform.localPosition = Vector3.zero;
                TurnVisual(false, playerWeapon);
            }

            Debug.Log("Player collided with weapon");

            weapon.parentTransform = other.transform;
            weapon.transform.SetParent(other.transform);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;

            TurnVisual(true, weapon);

            Debug.Log("Player successfully equipped with weapon.");
        }
        else
        {
            Debug.Log("Non-Player object entered the trigger.");
        }
    }

    // Mengaktifkan atau menonaktifkan visual dari weapon
    private void TurnVisual(bool on)
    {
        if (weapon != null)
        {
            weapon.gameObject.SetActive(on);
        }
    }

    private void TurnVisual(bool on, Weapon weapon)
    {
        if (weapon != null)
        {
            weapon.gameObject.SetActive(on);
        }
    }
}