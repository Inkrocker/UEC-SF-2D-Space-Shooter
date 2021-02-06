using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EarthRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject _earth;

    [SerializeField]
    private float _earthSpeed = 1;

    private void Update()
    {
        RotateEarth();
    }

    void RotateEarth()
    {
        transform.Rotate(0.0f, 0.0f, (0.25f * _earthSpeed * Time.deltaTime), Space.Self);
    }
}