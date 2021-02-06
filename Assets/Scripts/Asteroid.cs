using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _asteroidSpeed = 3;

    [SerializeField]
    private GameObject _asteroidExplosionPrefab;

    private Player _player;

    private SpawnManager _spawnManager;

    void Start()
    {
        transform.position = new Vector3(7.0f, 0.0f, 0.0f);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();

        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL!");
        }

        if(_player == null)
        {
            Debug.LogError("The Player is NULL!");
        }
    }

    void Update()
    {
        AsteroidRotation();
    }

    void AsteroidRotation()
    {
        transform.Rotate(0.0f, 0.0f, (-5.0f * _asteroidSpeed * Time.deltaTime), Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);

            if(_player != null)
            {
                _player.AddToScore(10);
            }
            _asteroidSpeed = 0;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            _spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.25f);
            Vector3 SpawnAsteroidExplosion = new Vector3(transform.position.x, 0.0f, 0.0f);
            Instantiate(_asteroidExplosionPrefab, SpawnAsteroidExplosion, Quaternion.identity);
        }

        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            
            if (player != null)
            {
                player.Damage();
            }
        }
    }
}
