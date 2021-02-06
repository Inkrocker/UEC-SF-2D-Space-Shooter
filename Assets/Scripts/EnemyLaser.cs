using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField]
    private float _enemyLaserSpeed = 6;

    void Update()
    {
        EnemyLaserMovementLeft();
    }

    void EnemyLaserMovementLeft()
    {
        transform.Translate(_enemyLaserSpeed * Vector3.left * Time.deltaTime);

        if (transform.position.x <= -11.0f)
        {
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject);
        }
    }
}
