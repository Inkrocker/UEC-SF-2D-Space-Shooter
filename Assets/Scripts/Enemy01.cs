using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    private float _enemy01Speed;
    [SerializeField]
    private int _enemyHealth = 3;
    public SpriteRenderer _spriteFlashColor;
    private Animator _enemy01_Anim;
    private AudioSource _audioSource;

    private Player _player;
    [SerializeField]
    private int _pointsAwarded;

    private void Start()
    {
        _enemy01Speed = Random.Range(2f, 3.5f);
        transform.position = new Vector3(11.0f, Random.Range(-4.0f, 4.25f), 0.0f);

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("The Enemy01 AudioSource is NULL!");
        }

        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("The Player is NULL!");
        }

        _enemy01_Anim = gameObject.GetComponent<Animator>();
        if (_enemy01_Anim == null)
        {
            Debug.LogError("The Enemy01 Animator component is NULL!");
        }
    }

    private void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        transform.Translate(_enemy01Speed * Vector3.left * Time.deltaTime);

        if (transform.position.x <= -11.0f)
        {
            float randomPositionY = Random.Range(-4.0f, 4.25f);

            transform.position = new Vector3(11.0f, randomPositionY, 0.0f);
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
            _enemy01Speed = Random.Range(0.25f, 1.75f);
            _enemy01_Anim.SetTrigger("OnEnemyDeath");
            _audioSource.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 1.5f);
        }

        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);

            _enemyHealth--;
            StartCoroutine(FlashRed());

            if (_enemyHealth == 0)
            {
                _player.AddToScore(_pointsAwarded);
                _enemy01Speed = Random.Range(0.25f, 1.75f);
                _enemy01_Anim.SetTrigger("OnEnemyDeath");
                _audioSource.Play();
                Destroy(GetComponent<Collider2D>());
                Destroy(this.gameObject, 1.5f);
            }
        }

        else if (other.tag == "BloomBomb")
        {
            _enemyHealth = 0;
            StartCoroutine(FlashRed());

            if (_enemyHealth == 0)
            {
                _player.AddToScore(_pointsAwarded);
                _enemy01Speed = Random.Range(0.25f, 1.75f);
                _enemy01_Anim.SetTrigger("OnEnemyDeath");
                _audioSource.Play();
                Destroy(GetComponent<Collider2D>());
                Destroy(this.gameObject, 1.5f);
            }
        }

        IEnumerator FlashRed()
        {
            _spriteFlashColor.color = Color.red;
            yield return new WaitForSeconds(0.125f);
            _spriteFlashColor.color = Color.white;

            if (_enemyHealth == 0)
            {
                _enemyHealth = 0;
                StopCoroutine(FlashRed());
            }
        }
    }
}
