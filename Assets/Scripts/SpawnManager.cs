using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool _stopSpawning = false;

    [SerializeField]
    private GameObject[] _enemyAsteroidPrefab;
    
    [SerializeField]
    private GameObject _enemyPrefab;
    private float RandomEnemyCount;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject[] _powerUpPrefabs;
    [SerializeField]
    private GameObject _lifeUpPrefab;
    [SerializeField]
    private GameObject _bloomBombPrefab;

    public void StartSpawning()
    {
        StartCoroutine(SpawnPowerUpsRoutine());
        StartCoroutine(SpawnLifeUpRarelyRoutine());
        RandomAmountEnemy01Spawned();
        StartCoroutine(AsteroidEnemyRoutine());
        StartCoroutine(VariantAsteroidEnemyRoutine());
        StartCoroutine(SpawnBloomBombRoutine());
    }

    //----------- ASTEROID SPAWNING  ----------------------------\\
    IEnumerator AsteroidEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(14);
            for (int i = 0; i < _enemyAsteroidPrefab.Length; i++)
            {
                Vector3 placeSpawningAsteroids = new Vector3(0, Random.Range(-4.5f, 9.6f), 0);
                Instantiate(_enemyAsteroidPrefab[i], placeSpawningAsteroids, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(7, 12f));
            }            
        }
    }

    IEnumerator VariantAsteroidEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(10);
            for (int i = 0; i < _enemyAsteroidPrefab.Length; i++)
            {
                Vector3 placeSpawningAsteroids = new Vector3(0, Random.Range(-4.5f, 9.6f), 0);
                Instantiate(_enemyAsteroidPrefab[i], placeSpawningAsteroids, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(2.25f, 5.25f));
            }
        }
    }

    //----------- ENEMY01 SPAWNING ----------------------------\\
    void RandomAmountEnemy01Spawned()
    {
        RandomEnemyCount = Random.Range(3, 8);

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
            yield return new WaitForSeconds(Random.Range(1.25f, 2.5f));
        }
    }

    //----------- POWER-UPS SPAWNING ----------------------------\\
    IEnumerator SpawnPowerUpsRoutine()
    {
        while(_stopSpawning == false)
        {
            yield return new WaitForSeconds(5);
            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(-4.0f, 4.25f), 11, 0);
            int randomPowerUp = Random.Range(0, 4);
            Instantiate(_powerUpPrefabs[randomPowerUp], posToSpawnPowerUp, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range (3, 7f));
        }
    }

    //----------- LIFE REPAIR KIT SPAWNING ----------------------------\\
    IEnumerator SpawnLifeUpRarelyRoutine()
    {
        while(_stopSpawning == false)
        {
            yield return new WaitForSeconds(15);
            Vector3 posToSpawnLifeUp = new Vector3(Random.Range(-4.0f, 4.25f), 11, 0);
            Instantiate(_lifeUpPrefab, posToSpawnLifeUp, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(15, 30f));
        }
    }

    //----------- BLOOM BOMBS SPAWNING ----------------------------\\

    IEnumerator SpawnBloomBombRoutine()
    {
        while(_stopSpawning == false)
        {
            yield return new WaitForSeconds(Random.Range(10, 20f));
            Vector3 posToSpawnBloomBomb = new Vector3(Random.Range(-4.0f, 4.25f), 11, 0);
            Instantiate(_bloomBombPrefab, posToSpawnBloomBomb, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(6, 12f));
        }
    }

    //----------- STOP SPAWNING ----------------------------\\
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
