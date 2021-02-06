using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{

    private float _moonSpeed = 0.75f;

    void Update()
    {
        transform.Translate(_moonSpeed * Vector3.left * Time.deltaTime);

        if (transform.position.x <= -24.76f)
        {
            transform.position = new Vector3(36.67f, -3.50f, 0.0f);
        }
    }
}