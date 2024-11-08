using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    // Kecepatan maksimum
    public Vector2 maxSpeed = new Vector2(7f, 5f); 
    // Waktu untuk mencapai kecepatan maksimum
    public Vector2 timeToFullSpeed = new Vector2(1f, 1f); 
    // Waktu untuk berhenti
    public Vector2 timeToStop = new Vector2(0.5f, 0.5f);
    // Batas kecepatan minimum untuk berhenti
    public Vector2 stopClamp = new Vector2(2.5f, 2.5f);

    // Menambahkan batas area kamera 
    public float xLimit = 8.5f; // Batas kanan/kiri
    public float yLimit = 4.5f; // Batas atas/bawah

    // Arah gerakan player sesuai input
    private Vector2 moveDirection;
    // Gaya yang diberikan ke player
    private Vector2 moveVelocity;
    // Gaya gesek yang diberikan agar player berhenti
    private Vector2 stopFriction;

    // Mendapatkan komponen
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = new Vector2(maxSpeed.x / timeToFullSpeed.x, 
        maxSpeed.y / timeToFullSpeed.y);
        stopFriction = new Vector2(moveVelocity.x / timeToStop.x, 
        moveVelocity.y / timeToStop.y);
    }

    // Memanggil method Move dari PlayerMovement
    private void FixedUpdate() {
        Move();
    }

    // Input pengguna untuk menentukan arah gerakan 
    public void Move() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Kecepatan berdasarkan input dan batas kecepatan maksimum
        Vector2 targetVelocity = new Vector2(
            moveDirection.x * maxSpeed.x,
            moveDirection.y * maxSpeed.y
        );

        // Mengatur kecepatan player
        Vector2 currentVelocity = rb.velocity;
        currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, 
        targetVelocity.x, stopFriction.x * Time.fixedDeltaTime);
        currentVelocity.y = Mathf.MoveTowards(currentVelocity.y, 
        targetVelocity.y, stopFriction.y * Time.fixedDeltaTime);
        rb.velocity = currentVelocity;

        // Batasi posisi pemain agar tidak keluar dari batas kamera
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -xLimit, xLimit);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -yLimit, yLimit);
        transform.position = clampedPosition;
    }

    // Mengembalikan true jika player sedang bergerak dan false jika tidak
    public bool IsMoving() {
        bool isMoving = Mathf.Abs(rb.velocity.x) > stopClamp.x || Mathf.Abs(rb.velocity.y) > stopClamp.y;
        Debug.Log("IsMoving status: " + isMoving); 
        return isMoving;
    }
}