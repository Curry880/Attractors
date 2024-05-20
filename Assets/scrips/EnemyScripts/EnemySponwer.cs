using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; // 出現させる敵のプレハブ
    [SerializeField] Transform player; // プレイヤーのTransform
    [SerializeField] int numberOfEnemies = 3; // 敵の数
    [SerializeField] float spawnRadius = 5f; // 敵の出現半径
    [SerializeField] float spawnInterval; // 敵の生成間隔
    // publicプロパティ：getはpublic、setはprivate
    public float SpawnInterval
    {
        get => spawnInterval;
        private set => spawnInterval = value;
    }

    float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemies();
            spawnTimer = 0f; // タイマーをリセット
        }
    }

    public void SpawnEnemies()
    {
        float angleStep = 360f / numberOfEnemies;
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float angle = i * angleStep;
            Vector3 spawnPosition = player.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad) * spawnRadius, Mathf.Sin(angle * Mathf.Deg2Rad) * spawnRadius, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
