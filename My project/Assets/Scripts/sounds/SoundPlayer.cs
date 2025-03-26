using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        SetVolume(AudioManager.Instance.SFXVolume);
    }
     public void SetVolume(float volume)
     {
        audioSource.volume = volume;
     }
}
