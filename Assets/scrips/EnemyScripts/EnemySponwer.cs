using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; // �o��������G�̃v���n�u
    [SerializeField] Transform player; // �v���C���[��Transform
    [SerializeField] int numberOfEnemies = 3; // �G�̐�
    [SerializeField] float spawnRadius = 5f; // �G�̏o�����a
    [SerializeField] float spawnInterval; // �G�̐����Ԋu
    // public�v���p�e�B�Fget��public�Aset��private
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
            spawnTimer = 0f; // �^�C�}�[�����Z�b�g
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
