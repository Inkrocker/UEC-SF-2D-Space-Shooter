using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAsteroid_Explosion : MonoBehaviour
{
    private void Update()
    {
        DestroyAsteroid();
    }

    private void DestroyAsteroid()
    {
        Destroy(this.gameObject, 1.0f);
    }
}