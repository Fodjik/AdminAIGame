using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemiesPerWave = 5;
    public float spawnInterval = 0.4f;

    private RoomWaveTracker roomTracker;

    private void Awake()
    {
        roomTracker = GetComponentInParent<RoomWaveTracker>();
    }

    public void StartWave()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        roomTracker.RegisterEnemy(enemy);
    }
}
