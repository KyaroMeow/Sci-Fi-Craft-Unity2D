
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        SetVolume(AudioManager.Instance.MusicVolume);
    }
     public void SetVolume(float volume)
     {
        audioSource.volume = volume;
     }
}
