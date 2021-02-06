using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonDamage : MonoBehaviour
{
    private Player _player;

    private EnemyAsteroid _enemyAsteroid;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        if (_player == null)
        {
            Debug.LogError("The Player is NULL!");
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
        }
    }
}
