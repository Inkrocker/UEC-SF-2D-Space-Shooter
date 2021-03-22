using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomBomb : MonoBehaviour
{
    [SerializeField]
    private float _bloomBombSpeed = 4;

    [SerializeField]
    private GameObject _bombExplosionPrefab;

    private void Update()
    {
        BloomBombMovement();
    }

    private void BloomBombMovement()
    {
        transform.Translate(_bloomBombSpeed * Vector3.right * Time.deltaTime);
        
        if (transform.position.y <= -4.2f)
        {
            Destroy(this.gameObject);
            BloomBombExplodes();
        }
    }

    private void BloomBombExplodes()
    {
        Vector3 posToSpawnBombExplosion = new Vector3(transform.position.x, -4.2f, 0);
        var tempBomb = Instantiate(_bombExplosionPrefab, posToSpawnBombExplosion, Quaternion.identity);
        Destroy(tempBomb, 2.3f);
    }
}
