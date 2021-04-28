using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSurfaceBack : MonoBehaviour
{
    [SerializeField]
    private float _moonSpeed;

    void Update()
    {
        MoonMovementBack();
    }

    void MoonMovementBack()
    {
        transform.Translate(_moonSpeed * Vector3.left * Time.deltaTime);

        if (transform.position.x <= -20.48f)
        {
            transform.position = new Vector3(40.96f, -2.95f, -0.5f);
        }
    }
}