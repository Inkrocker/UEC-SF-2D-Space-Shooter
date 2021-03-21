using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed = 8.0f;

    private void Update()
    {
        LaserMoveRight();
    }

    private void LaserMoveRight()
    {
        transform.Translate(_laserSpeed * Vector3.right * Time.deltaTime);

        if (transform.position.x >= 12.0f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
