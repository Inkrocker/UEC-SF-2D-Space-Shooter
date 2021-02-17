using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    private float _enemy01Speed;

    private Player _player;

    private Animator _enemy01_Anim;

    private int _enemyHealth = 2;

    public SpriteRenderer _spriteFlashColor;

    private AudioSource _audioSource;

    private void Start()
    {
        _enemy01Speed = Random.Range(2.25f, 3.5f);
        transform.position = new Vector3(11.0f, Random.Range (-4.0f, 4.25f), 0.0f);
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();

        if (_player == null)
        {
            Debug.LogError("The Player is NULL!");
        }

        _enemy01_Anim = gameObject.GetComponent<Animator>();

        if(_enemy01_Anim == null)
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
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            
            if(player != null)
            {
                player.Damage();
            }
            _enemy01Speed = 0;
            _enemy01_Anim.SetTrigger("OnEnemyDeath");
            _audioSource.Play();
            Destroy(this.gameObject, 1.3f);
        }

        else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);

            _enemyHealth--;
            StartCoroutine(FlashRed());

            if(_enemyHealth == 0 && _player != null)
            {
                _player.AddToScore(10);
                _enemy01Speed = 0;
                _enemy01_Anim.SetTrigger("OnEnemyDeath");
                _audioSource.Play();
                Destroy(GetComponent<Collider2D>());
                Destroy(this.gameObject, 1.3f);
            }
        }
    }

    IEnumerator FlashRed()
    {
        _spriteFlashColor.color = Color.red;
        yield return new WaitForSeconds(0.125f);
        _spriteFlashColor.color = Color.white;

        if(_enemyHealth == 0)
        {
            _enemyHealth = 0;
            StopCoroutine(FlashRed());
        }
    }
}
