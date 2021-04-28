using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSurfaceFront : MonoBehaviour
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
            transform.position = new Vector3(40.96f, -0.01f, -6.8f);
        }
    }
}
