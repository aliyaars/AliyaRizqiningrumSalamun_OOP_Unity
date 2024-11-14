using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float horizontalSpeed = 2f;
    private Vector2 travelDirection;
    public GameObject enemyTemplate;

    void Start()
    {
        SetRandomSideSpawn();
        SpawnMultipleInstances(enemyTemplate, Random.Range(3, 7));
    }

    void Update()
    {
        transform.Translate(travelDirection * horizontalSpeed * Time.deltaTime);

        if (transform.position.x < -Screen.width / 80f || transform.position.x > Screen.width / 80f)
        {
            SetRandomSideSpawn();
        }
    }

    private void SetRandomSideSpawn()
    {
        float spawnX = Random.Range(0, 2) == 0 ? -Screen.width / 110f : Screen.width / 120f;
        float spawnY = Random.Range(-Screen.height / 80f, Screen.height / 80f);

        transform.position = new Vector2(spawnX, spawnY);
        travelDirection = spawnX < 0 ? Vector2.right : Vector2.left;

        transform.rotation = Quaternion.identity;
    }

    public static void SpawnMultipleInstances(GameObject prefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject instance = Instantiate(prefab);
            EnemyHorizontal enemyScript = instance.GetComponent<EnemyHorizontal>();
            enemyScript?.SetRandomSideSpawn();
        }
    }
}
