using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _alienMonolithPrefab;

    [SerializeField]
    private GameObject[] _enemyAsteroidPrefab;

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject[] _powerUpPrefabs;

    private float RandomEnemyCount;

    private bool _stopSpawning = false;


    public void StartSpawning()
    {
        StartCoroutine(SpawnPowerUpsRoutine());
        RandomAmountOfEnemy01Spawned();
        StartCoroutine(AsteroidEnemyRoutine());
        StartCoroutine(VariantAsteroidEnemyRoutine());
    }

    IEnumerator AsteroidEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(5.5f);
            for (int i = 0; i < _enemyAsteroidPrefab.Length; i++)
            {
                Vector3 placeSpawningAsteroids = new Vector3(0.0f, Random.Range(-4.5f, 9.6f), 0.0f);
                Instantiate(_enemyAsteroidPrefab[i], placeSpawningAsteroids, Quaternion.Euler(0, 0, -30));
                yield return new WaitForSeconds(3.75f);
            }            
        }
    }

    IEnumerator VariantAsteroidEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(4.5f);
            for (int i = 0; i < _enemyAsteroidPrefab.Length; i++)
            {
                Vector3 placeSpawningAsteroids = new Vector3(0.0f, Random.Range(-4.5f, 9.6f), 0.0f);
                Instantiate(_enemyAsteroidPrefab[i], placeSpawningAsteroids, Quaternion.Euler(0, 0, -60));
                yield return new WaitForSeconds(2.25f);
            }
        }
    }

    void RandomAmountOfEnemy01Spawned()
    {
        RandomEnemyCount = Random.Range(5, 8);

        for (int i = 0; i < RandomEnemyCount; i++)
        {
            StartCoroutine(SpawnEnemy01Routine());
        }
    }

    IEnumerator SpawnEnemy01Routine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(3.0f);
            Vector3 placeToSpawn = new Vector3(Random.Range (-3.25f, 4.25f), 11.0f, 0.0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, placeToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(1.5f, 2.75f));
        }
    }

    IEnumerator SpawnPowerUpsRoutine()
    {
        while(_stopSpawning == false)
        {
            yield return new WaitForSeconds(3.0f);
            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(-4.0f, 4.25f), 11.0f, 0.0f);
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(_powerUpPrefabs[randomPowerUp], posToSpawnPowerUp, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range (2.5f, 5.0f));
        }
    }

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
