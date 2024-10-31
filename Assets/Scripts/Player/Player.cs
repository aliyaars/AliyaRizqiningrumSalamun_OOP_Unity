using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance; 
    private PlayerMovement playerMovement;
    private Animator animator;

    // Menetapkan player sebagai singleton dan tidak dihancurkan
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else {
            Destroy(gameObject); 
        }
    }

    // Mendapatkan komponen PlayerMovement dan Animator
    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        animator = transform.Find("Engine/EngineEffect").GetComponent<Animator>();
    }

    // Memanggil method Move dari PlayerMovement
    private void FixedUpdate() {
        playerMovement.Move();
    }

    // Mengatur nilai Bool dari parameter IsMoving milik Animator
    private void LateUpdate() {
        bool isMoving = playerMovement.IsMoving();
        animator.SetBool("IsMoving", isMoving);
        Debug.Log("IsMoving pada Animator: " + isMoving);
    }
}
