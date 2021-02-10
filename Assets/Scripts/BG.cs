using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    [SerializeField]
    private float _backgroundSpeed;

    void Update()
    {
        Background0Movement();
    }

    void Background0Movement()
    {
        transform.Translate(_backgroundSpeed * Vector3.left * Time.deltaTime);

        if (transform.position.x < -23f)
        {
            transform.position = new Vector3(22f, 0.6f, 0.0f);
        }
    }
}
