using UnityEngine;

public class EnemyForward : Enemy
{
    public float descentSpeed = 2f;
    public GameObject enemyTemplate;

    void Start()
    {
        PlaceAtTop();
        SpawnMultipleInstances(enemyTemplate, Random.Range(3, 7));
    }

    void Update()
    {
        transform.Translate(Vector2.down * descentSpeed * Time.deltaTime);

        if (transform.position.y < -Screen.height / 85f)
        {
            PlaceAtTop();
        }
    }

    private void PlaceAtTop()
    {
        float randomX = Random.Range(-Screen.width / 105f, Screen.width / 105f);
        transform.position = new Vector2(randomX, Screen.height / 85f);
        transform.rotation = Quaternion.identity;
    }

    public static void SpawnMultipleInstances(GameObject prefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject instance = Instantiate(prefab);
            EnemyForward enemyScript = instance.GetComponent<EnemyForward>();
            enemyScript?.PlaceAtTop();
        }
    }
}
