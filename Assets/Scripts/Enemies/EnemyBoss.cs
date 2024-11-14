using UnityEngine;

public class EnemyBoss : Enemy
{
    public float movementSpeed = 2f;
    private Vector2 direction;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        SetRandomSidePosition();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime);

        if (transform.position.x < -Screen.width / 80f || transform.position.x > Screen.width / 80f)
        {
            SetRandomSidePosition();
        }
    }

    private void SetRandomSidePosition()
    {
        float spawnX = Random.Range(0, 2) == 0 ? Screen.width / 120f : -Screen.width / 110f;
        float spawnY = Random.Range(-Screen.height / 80f, Screen.height / 80f);

        transform.position = new Vector2(spawnX, spawnY);
        direction = spawnX < 0 ? Vector2.right : Vector2.left;

        spriteRenderer.flipX = direction == Vector2.left;
        transform.rotation = Quaternion.identity;
    }
}
