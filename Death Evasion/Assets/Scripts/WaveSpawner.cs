using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public float spawnDelay;
    public Transform[] spawnPoints; // Array of spawn points for the wave
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public float timeBetweenWaves = 5f;
    public string nextSceneName; // The name of the scene to transition to after all waves are completed
    private int currentWaveIndex = 0;
    private int totalEnemies;

    private void Start()
    {
        totalEnemies = 0;
        foreach (var wave in waves)
        {
            totalEnemies += wave.enemyCount;
        }

        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waves.Length)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            Wave currentWave = waves[currentWaveIndex];
            Debug.Log("Wave " + (currentWaveIndex + 1) + " incoming!");

            for (int i = 0; i < currentWave.enemyCount; i++)
            {
                SpawnEnemy(currentWave.enemyPrefab, currentWave.spawnPoints);
                yield return new WaitForSeconds(currentWave.spawnDelay);
            }

            currentWaveIndex++;
        }

        Debug.Log("All waves completed!");

        // Check if all enemies are defeated
        StartCoroutine(CheckAllEnemiesDefeated());
    }

    IEnumerator CheckAllEnemiesDefeated()
    {
        while (true)
        {
            yield return null;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            int remainingEnemies = enemies.Length;

            if (remainingEnemies == 0 && currentWaveIndex == waves.Length)
            {
                // Transition to the next scene
                if (!string.IsNullOrEmpty(nextSceneName))
                {
                    SceneManager.LoadScene(nextSceneName);
                }

                yield break;
            }
        }
    }

    void SpawnEnemy(GameObject enemyPrefab, Transform[] spawnPoints)
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
