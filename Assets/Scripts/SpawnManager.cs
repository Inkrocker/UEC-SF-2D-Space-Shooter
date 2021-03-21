using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyAsteroidPrefab;

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject[] _powerUpPrefabs;

    [SerializeField]
    private GameObject _lifeUpPrefab;

    [SerializeField]
    private GameObject _bloomBombPrefab;

    private float RandomEnemyCount;

    private bool _stopSpawning = false;


    public void StartSpawning()
    {
        StartCoroutine(SpawnPowerUpsRoutine());
        StartCoroutine(SpawnLifeUpRarelyRoutine());
        RandomAmountEnemy01Spawned();
        StartCoroutine(AsteroidEnemyRoutine());
        StartCoroutine(VariantAsteroidEnemyRoutine());
        StartCoroutine(SpawnBloomBombRoutine());
    }

//----------- ASTEROID SPAWNING  ----------------
    IEnumerator AsteroidEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(13);
            for (int i = 0; i < _enemyAsteroidPrefab.Length; i++)
            {
                Vector3 placeSpawningAsteroids = new Vector3(0, Random.Range(-4.5f, 9.6f), 0);
                Instantiate(_enemyAsteroidPrefab[i], placeSpawningAsteroids, Quaternion.identity);
                yield return new WaitForSeconds(7);
            }            
        }
    }

    IEnumerator VariantAsteroidEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(21);
            for (int i = 0; i < _enemyAsteroidPrefab.Length; i++)
            {
                Vector3 placeSpawningAsteroids = new Vector3(0, Random.Range(-4.5f, 9.6f), 0);
                Instantiate(_enemyAsteroidPrefab[i], placeSpawningAsteroids, Quaternion.identity);
                yield return new WaitForSeconds(2.25f);
            }
        }
    }

//----------- ENEMY01 SPAWNING ----------------
    void RandomAmountEnemy01Spawned()
    {
        RandomEnemyCount = Random.Range(3, 5);

        for (int i = 0; i < RandomEnemyCount; i++)
        {
            StartCoroutine(SpawnEnemy01Routine());
        }
    }

    IEnumerator SpawnEnemy01Routine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(3);
            Vector3 placeToSpawn = new Vector3(Random.Range (-3.25f, 4.25f), 11, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, placeToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(1.5f, 2.75f));
        }
    }

//----------- POWER-UPS SPAWNING ----------------
    IEnumerator SpawnPowerUpsRoutine()
    {
        while(_stopSpawning == false)
        {
            yield return new WaitForSeconds(3);
            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(-4.0f, 4.25f), 11, 0);
            int randomPowerUp = Random.Range(0, 4);
            Instantiate(_powerUpPrefabs[randomPowerUp], posToSpawnPowerUp, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range (3, 7f));
        }
    }

//----------- LIFE REPAIR KIT SPAWNING ----------------
    IEnumerator SpawnLifeUpRarelyRoutine()
    {
        while(_stopSpawning == false)
        {
            yield return new WaitForSeconds(15);
            Vector3 posToSpawnLifeUp = new Vector3(Random.Range(-4.0f, 4.25f), 11, 0);
            Instantiate(_lifeUpPrefab, posToSpawnLifeUp, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(15, 31));
        }
    }

//----------- BLOOM BOMBS SPAWNING ----------------

    IEnumerator SpawnBloomBombRoutine()
    {
        while(_stopSpawning == false)
        {
            yield return new WaitForSeconds(Random.Range(40f, 60f));
            Vector3 posToSpawnBloomBomb = new Vector3(Random.Range(-4.0f, 4.25f), 11, 0);
            Instantiate(_bloomBombPrefab, posToSpawnBloomBomb, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(13, 20));
        }
    }

//----------- STOP SPAWNING ----------------
    public void PlayerDead()
    {
        _stopSpawning = true;
        EnemyCleanUp();
    }

    private void EnemyCleanUp()
    {
        if(_enemyContainer == true)
        {
            _enemyContainer.SetActive(false);
        }
    }
}
