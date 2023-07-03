using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPreFab;
    public GameObject powerupPreFab;
    public float range;

    private int enemyCount;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUP();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0) {
            SpawnEnemyWave(++waveNumber);
            SpawnPowerUP();
        }
    }

    Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-range, range);
        float spawnPosZ = Random.Range(-range, range);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    void SummonEnemy() {
        Instantiate(enemyPreFab, GenerateSpawnPosition(), enemyPreFab.transform.rotation);
    }

    void SpawnEnemyWave(int count) {
        for (int i = 0; i < count; ++i) {
            SummonEnemy();
        }
    }

    void SpawnPowerUP() {
        Instantiate(powerupPreFab, GenerateSpawnPosition(), powerupPreFab.transform.rotation);
    }

}
