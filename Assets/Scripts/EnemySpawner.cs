
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject enemyPrefab;
    public float spawnRadius = 8f;
    public float spawnInterval = 2f;
    public int maxEnemies = 20;

    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length >= maxEnemies)
            return;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition =
            (Vector2)transform.position + randomDirection * spawnRadius;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}