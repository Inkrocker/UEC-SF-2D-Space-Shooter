using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]

public class SoundToggle : MonoBehaviour
{
    private Toggle _soundToggle;

    [SerializeField]
    private AudioSource _musicToggle;

    private void Start()
    {
        _soundToggle = GetComponent<Toggle>();
        if(AudioListener.volume == 1)
        {
            _soundToggle.isOn = true;
        }
    }

    public void ToggleSounds(bool soundsAudioIn)
    {
        if (soundsAudioIn)
        {
            AudioListener.volume = 1;
        }

        else
        {
            AudioListener.volume = 0;
        }
    }

    public void ToggleMusic(bool musicAudioIn)
    {
        if (musicAudioIn)
        {
            _musicToggle.enabled = true;
        }

        else
        {
            _musicToggle.enabled = false;
        }
    }
}