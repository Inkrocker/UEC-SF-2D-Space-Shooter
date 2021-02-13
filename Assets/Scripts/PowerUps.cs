using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    private float _powerUpSpeed;

    [SerializeField] // 0 = Triple Shot, 1 = Speed, 2 = Shield, 3 = LifeUp
    private int powerUpsID;

    [SerializeField]
    private AudioClip _clip;

    private void Start()
    {
        transform.position = new Vector3(11.0f, Random.Range(-4.0f, 4.25f), 0.0f);
    }

    private void Update()
    {
        PowerUpMovement();
    }

    void PowerUpMovement()
    {
        transform.Translate(_powerUpSpeed * Vector3.left * Time.deltaTime);

        if(transform.position.x <= -11.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_clip, transform.position);

            if(player != null)
            {
                switch (powerUpsID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedPowerUpActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                    case 3:
                        player.LifeUpActive();
                        break;
                    default:
                        Debug.Log("Default value");
                        break;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
