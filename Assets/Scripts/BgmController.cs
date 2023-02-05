using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    AudioClip currentAudioClip;
    string[] songNames = { "_Arcana_ Preview", "Bartender", "Cat caffe", "Countryside", "Cue", "Florist", "Morning rain", "Oceanside", "Rainy Forest" };

    private void Start()
    {
        PlayNextSong();
    }

    void PlayNextSong()
    {

        GetComponent<AudioSource>().clip = getRandomAudioClip();
        audioSource.Play();
        Invoke("PlayNextSong", GetComponent<AudioSource>().clip.length);
    }

    AudioClip getRandomAudioClip()
    {
        string nextSong = songNames[Random.Range(0, 9)];

        if (currentAudioClip != null)
        {
            if (nextSong == currentAudioClip.name)
            {
                nextSong = songNames[Random.Range(0, 9)];
            }
        }

        return Resources.Load<AudioClip>("BGM/" + nextSong);
    }

}
