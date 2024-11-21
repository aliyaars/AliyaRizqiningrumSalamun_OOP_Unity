using UnityEngine;

public class EnemyTargeting : Enemy
{
    private Transform playerPosition;
    private float movementSpeed = 2.0f;
    public GameObject enemyTemplate;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerPosition = player.transform;
        }
        else
        {
            Debug.LogWarning("Player not found. EnemyTargeting won't follow.");
        }

        GenerateEnemies(enemyTemplate, Random.Range(1, 6));
    }

    void Update()
    {
        if (playerPosition != null)
        {
            Vector2 targetDirection = (playerPosition.position - transform.position).normalized;
            transform.Translate(targetDirection * movementSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void GenerateEnemies(GameObject prefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            float spawnX = Random.Range(0, 2) == 0 ? -Screen.width / 110f : Screen.width / 110f;
            float spawnY = Random.Range(-Screen.height / 80f, Screen.height / 80f);

            GameObject instance = Instantiate(prefab, new Vector2(spawnX, spawnY), Quaternion.identity);
            EnemyTargeting enemyScript = instance.GetComponent<EnemyTargeting>();

            if (enemyScript != null)
            {
                enemyScript.playerPosition = playerPosition;
            }
        }
    }
}