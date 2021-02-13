using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAsteroid : MonoBehaviour
{
    private float _asteroidSpeed;

    [SerializeField]
    GameObject _explosionPrefab;

    private Player _player;

    public SpriteRenderer _spriteFlashColor;

    private int _asteroidHealth = 2;

    private AudioSource _audioSource;

    private void Start()
    {
        _asteroidSpeed = Random.Range(0.75f, 2.0f);
        transform.position = new Vector3(Random.Range(0.0f, 9.6f), 6.0f, 0.0f);
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();


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
        transform.Translate(_asteroidSpeed * Vector3.down * Time.deltaTime);

        if(transform.position.y <= -4.2f)
        {
            _asteroidSpeed = 0;
            Destroy(this.gameObject);
            Vector3 SpawnEnemyAsteroidExplosion = new Vector3(transform.position.x, transform.position.y, 0);
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
            _asteroidSpeed = 0;
            _audioSource.Play();
            Destroy(this.gameObject);
            Vector3 SpawnEnemyAsteroidExplosion = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(_explosionPrefab, SpawnEnemyAsteroidExplosion, Quaternion.identity);
        }

        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            
            _asteroidHealth--;
            StartCoroutine(FlashAsteroidRed());

            if (_asteroidHealth == 0 && _player != null)
            {
                _player.AddToScore(30);
                _asteroidSpeed = 0;
                _audioSource.Play();
                Destroy(GetComponent<Collider2D>());
                Destroy(this.gameObject);
                Vector3 SpawnEnemyAsteroidExplosion = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(_explosionPrefab, SpawnEnemyAsteroidExplosion, Quaternion.identity);
            }
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
