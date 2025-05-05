using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    public List<GameObject> enemyPrefabs;
    public Transform[] spawnPoints;

    public float spawnInterval = 10f;
    public int enemiesPerWave = 3;
    public int waveIncrement = 1;
    public int maxEnemiesPerWave = 10;

    private int currentWave = 0;

    void Start() {
        FindObjectOfType<HUDController>().UpdateWave(0);
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop() {
        yield return new WaitForSeconds(1);

        while (true) {
            int enemiesThisWave = Mathf.Min(enemiesPerWave + (currentWave * waveIncrement), maxEnemiesPerWave);
            SpawnWave(enemiesThisWave);

            currentWave++;
            FindObjectOfType<HUDController>().UpdateWave(currentWave);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnWave(int count) {
        for (int i = 0; i < count; i++) {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
