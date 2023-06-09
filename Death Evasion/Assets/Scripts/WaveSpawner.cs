using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, COUNTING, WAITING}

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public int nextWave;

    public float timeBetweenWaves = 5f;
    public float waveCountDown = 0f;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;


    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                // Begin a new round
            }
        }
        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave (waves [nextWave] ) );
            }
        }

        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive()
    {
        
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds (1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        // Spawn enemy
        Debug.Log("Spawing Enemy:  " + _enemy.name);
    }
}


