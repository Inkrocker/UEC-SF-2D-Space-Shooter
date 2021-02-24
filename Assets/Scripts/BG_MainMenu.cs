using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_MainMenu : MonoBehaviour
{
    [SerializeField]
    private float _bgSpeed;

    [SerializeField]
    private GameObject _backgroundPrefab;

    [SerializeField]
    private GameObject _backgroundPrefab2;

    private void Update()
    {
        BackgroundPosition();
    }

    void BackgroundPosition()
    {
        transform.Translate(_bgSpeed * Vector3.left * Time.deltaTime);

        if(transform.localPosition.x < -1024f)
        {
            transform.localPosition = new Vector3(1024f, 0.0f, 0.0f);
        }
    }
}
