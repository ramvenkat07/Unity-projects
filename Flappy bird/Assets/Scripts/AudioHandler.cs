using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField]
    AudioSource coinAudioSource;
    [SerializeField]
    AudioSource gameOverAudioSource;

    public void playCoinAudioSource()
    {
        if (coinAudioSource != null) 
        {
            coinAudioSource.Play();
        }
    }

    public void playGameOverAudioSource()
    {
        if (coinAudioSource != null)
        {
            gameOverAudioSource.Play();
        }
    }
}
