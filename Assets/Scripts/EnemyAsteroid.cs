using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAsteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionPrefab;

    private Player _player;

    public SpriteRenderer _spriteFlashColor;

    [SerializeField]
    private int _asteroidHealth;

    [SerializeField]
    private int _pointsAwarded;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(0.0f, 9.6f), 7.35f, 0.0f);

        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("The Player is NULL!");
        }
    }

    private void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {
        if (transform.position.y <= -4.2f != transform.position.x <= -12f)
        {
            Destroy(this.gameObject);
            Vector3 SpawnEnemyAsteroidExplosion = new Vector3(transform.position.x, transform.position.y);
            Instantiate(_explosionPrefab, SpawnEnemyAsteroidExplosion, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
            Vector3 SpawnEnemyAsteroidExplosion = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(_explosionPrefab, SpawnEnemyAsteroidExplosion, Quaternion.identity);
        }

        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);

            _asteroidHealth--;
            StartCoroutine(FlashAsteroidRed());

            if (_asteroidHealth == 0)
            {
                Destroy(GetComponent<Collider2D>());
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(this.gameObject);
                StartCoroutine(AddToScore());
                Vector3 SpawnEnemyAsteroidExplosion = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(_explosionPrefab, SpawnEnemyAsteroidExplosion, Quaternion.identity);
            }
        }

        else if (other.tag == "BloomBomb")
        {
            _asteroidHealth = 0;
            StartCoroutine(FlashAsteroidRed());

            if (_asteroidHealth == 0)
            {
                Destroy(GetComponent<Collider2D>());
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(this.gameObject);
                StartCoroutine(AddToScore());
                Vector3 SpawnEnemyAsteroidExplosion = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(_explosionPrefab, SpawnEnemyAsteroidExplosion, Quaternion.identity);
            }
        }

        IEnumerator AddToScore()
        {
            if(_player != null)
            {
                _player.AddToScore(_pointsAwarded);
                yield return new WaitForSeconds(0.2f);
            }
        }

        IEnumerator FlashAsteroidRed()
        {
            _spriteFlashColor.color = Color.red;
            yield return new WaitForSeconds(0.125f);
            _spriteFlashColor.color = Color.white;

            if (_asteroidHealth == 0)
            {
                _asteroidHealth = 0;
                StopCoroutine(FlashAsteroidRed());
            }
        }
    }
}
