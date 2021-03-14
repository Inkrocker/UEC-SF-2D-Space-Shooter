using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("The AudioSource is NULL!");
        }
        AudioclipExplosion();
    }

    private void AudioclipExplosion()
    {
        Destroy(this.gameObject, 2f);
        _audioSource.Play();
    }
}