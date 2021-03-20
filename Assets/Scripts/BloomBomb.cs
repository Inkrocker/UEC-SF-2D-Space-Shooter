using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomBomb : MonoBehaviour
{
    [SerializeField]
    private float _bloomBombSpeed = 2;

    private void Update()
    {
        BloomBombMovement();
    }

    public void BloomBombMovement()
    {
        transform.Translate(_bloomBombSpeed * Vector3.right * Time.deltaTime);

        if(transform.position.y <= -4.2f)
        {
            Destroy(this.gameObject);
        }
    }
}
