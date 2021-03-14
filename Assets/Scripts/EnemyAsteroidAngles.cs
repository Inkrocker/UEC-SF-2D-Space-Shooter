using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAsteroidAngles : MonoBehaviour
{

    private void Update()
    {
        AsteroidAngles();
    }
    void AsteroidAngles()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 30f);
    }
}
