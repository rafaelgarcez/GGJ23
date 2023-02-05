using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip click1, click2, click3;

    [SerializeField] AudioClip finished, treeReveal;
    public void PlayClick1()
    {
        audioSource.PlayOneShot(click1);
    }

    public void PlayClick2()
    {
        audioSource.PlayOneShot(click2);
    }

    public void PlayClick3()
    {
        audioSource.PlayOneShot(click3);
    }

    public void PlayFinished()
    {
        audioSource.PlayOneShot(finished);
    }
    public void PlayTreeReveal()
    {
        audioSource.PlayOneShot(treeReveal);
    }
}
