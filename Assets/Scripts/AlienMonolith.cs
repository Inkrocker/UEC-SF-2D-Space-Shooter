﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMonolith : MonoBehaviour
{
    [SerializeField]
    private GameObject _monolithExplosionPrefab;

    private int _monolithHealth = 10;

    public SpriteRenderer spriteFlashColor;

    private Player _player;

    private SpawnManager _spawnManager;

    void Start()
    {   transform.position = new Vector3(12.0f, 0.0f, 0.0f);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
       
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL!");
        }

        if (_player == null)
        {
            Debug.LogError("The Player is NULL!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);

            _monolithHealth--;
            StartCoroutine(FlashRed());

            if (_monolithHealth == 0)
            {
                _spawnManager.StartSpawning();
                Destroy(this.gameObject, 0.3f);
                Vector3 SpawnMonolithExplosion = new Vector3(transform.position.x, transform.position.y, 0.0f);
                Instantiate(_monolithExplosionPrefab, SpawnMonolithExplosion, Quaternion.identity);
            }

            if(_player != null)
            {
                _player.AddToScore(10);
            }
           
        }

        if (other.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
        }
    }

    public IEnumerator FlashRed()
    {
        spriteFlashColor.color = Color.red;
        yield return new WaitForSeconds(0.115f);
        spriteFlashColor.color = Color.white;

        if(_monolithHealth == 0)
        {
            _monolithHealth = 0;
            StopCoroutine(FlashRed());
        }
    }
}
