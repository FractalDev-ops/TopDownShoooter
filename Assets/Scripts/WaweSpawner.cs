using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaweSpawner : MonoBehaviour
{

    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    private Wave currentWave;
    private int currentWaweIndex;
    private Transform player;

    private bool finishSpawning;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        StartCoroutine(StartNextWave(currentWaweIndex));
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];

        for (int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }

            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

            if (i == currentWave.count - 1)
            {
                finishSpawning = true;
            }
            else
            {
                finishSpawning = false;
            }

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }
    private void Update()
    {
        if (finishSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0);
        {
            finishSpawning = false;
            if (currentWaweIndex + 1 < waves.Length){
                currentWaweIndex++;
                StartCoroutine(StartNextWave(currentWaweIndex));
            } else
            {
                Debug.Log("GAME FINISHED");
            }
        }
    }

}
