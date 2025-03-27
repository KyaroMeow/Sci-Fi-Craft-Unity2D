using UnityEngine;

public class SFXSource : MonoBehaviour
{
    public static SFXSource Instance;

    public AudioSource SFXAudioSource;
    public AudioSource MusicAudioSource;
    public AudioClip ScaryAmbient;
    public AudioClip Alarm;
    public AudioClip hower;
    public AudioClip click;
    public AudioClip coock;
    public AudioClip error;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayHower(){
        SFXAudioSource.PlayOneShot(hower);
    }
    public void PlayClick(){
        SFXAudioSource.PlayOneShot(click);
    }
    public void PlayCoock(){
        SFXAudioSource.PlayOneShot(coock);
    }
    public void PlayError(){
        SFXAudioSource.PlayOneShot(error);
    }
}
