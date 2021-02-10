using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField]
    private float _moonSpeed;

    void Update()
    {
        transform.Translate(_moonSpeed * Vector3.left * Time.deltaTime);

        if (transform.position.x <= -20.48f)
        {
            transform.position = new Vector3(40.96f, -3.50f, 0.0f);
        }
    }
}