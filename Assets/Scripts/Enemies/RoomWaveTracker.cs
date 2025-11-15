using System.Collections.Generic;
using UnityEngine;

public class RoomWaveTracker : MonoBehaviour
{
    public EnemySpawner[] spawners;

    private List<GameObject> aliveEnemies = new List<GameObject>();
    private bool waveStarted = false;

    private RunManager runManager;

    private void Awake()
    {
        runManager = FindFirstObjectByType<RunManager>();

    }

    private void Start()
    {
        foreach (var s in spawners)
            s.gameObject.SetActive(false);
    }

    public void StartWave()
    {
        if (waveStarted)
            return;

        waveStarted = true;

        foreach (var spawner in spawners)
        {
            spawner.gameObject.SetActive(true);
            spawner.StartWave();
        }
    }

    public void RegisterEnemy(GameObject enemy)
    {
        aliveEnemies.Add(enemy);
        Enemy e = enemy.GetComponent<Enemy>();
        e.onDeath += () => OnEnemyDeath(enemy);  
    }

    private void OnEnemyDeath(GameObject enemy)
    {
        if (aliveEnemies.Contains(enemy))
            aliveEnemies.Remove(enemy);

        if (aliveEnemies.Count == 0)
            OnWaveCleared();
    }

    private void OnWaveCleared()
    {
        waveStarted = false;
        runManager.RoomCleared();   
    }
}
