using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAngles : MonoBehaviour
{
    [SerializeField]
    private float _angleSpeedX;
    [SerializeField]
    private float _angleSpeedY;

    [SerializeField]
    private float _angleTranslateX;
    [SerializeField]
    private float _angleTranslateY;

    private void Update()
    {
        Angle();
    }
    void Angle()
    {
        transform.Translate (_angleTranslateX * _angleSpeedX * Time.deltaTime, _angleTranslateY * _angleSpeedY * Time.deltaTime, 0f, Space.World);
    }
}
