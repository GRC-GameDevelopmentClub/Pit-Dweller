using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wSpawner : MonoBehaviour {
    public enum SpawnState
    {
        spawning, waiting, counting
    }
    public SpawnState state = SpawnState.waiting;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject[] enemies;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountDown;
    [SerializeField]
    private float searchCountDown = 1f;
    private int nextWave = 0;
    // Use this for initialization
    void Start () {
        if (spawnPoints.Length == 0)
        {
            Debug.Log("No Spawn Point Referenced");
        }
        waveCountDown = timeBetweenWaves;
    }
	
	// Update is called once per frame
	void Update () {
        if (state == SpawnState.waiting)
        {
            if (!IsEnemyAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (state != SpawnState.spawning)
        {
            waveCountDown -= Time.deltaTime;
        }
        if (waveCountDown <= 0)
        {
            if (state != SpawnState.spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.counting;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            SceneManager.LoadScene("Win");
            Debug.Log("You SURVIVED! ...Again?");
        }
        else
        {
            nextWave++;
        }

    }

    bool IsEnemyAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Worm") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave" + _wave.name);
        state = SpawnState.spawning;
        for (int i = 0; i < _wave.count; i++)
        {
            Spawn(_wave.enemies[Random.Range(0, _wave.enemies.Length)]);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.waiting;

        yield break;

    }

    void Spawn(GameObject _enemies)
    {
        Debug.Log("Spawning Worm" + _enemies.name);


        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemies, _sp.position, _sp.rotation);
    }
}
