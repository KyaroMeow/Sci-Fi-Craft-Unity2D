using UnityEngine;

public class SFXSource : MonoBehaviour
{
    public static SFXSource Instance;
    public AudioSource MusicBack;
    public AudioSource ScaryMusicAudioSource;
    public AudioSource Alarm;
    public AudioSource SFXAudioSource;
    public AudioClip hower;
    public AudioClip click;
    public AudioClip boom;
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
    public void PlayBoom(){
        AlarmOff();
        BackOff();
        SFXAudioSource.PlayOneShot(boom);
    }
    public void PlayError(){
        SFXAudioSource.PlayOneShot(error);
    }
    public void ScaryAmbientOn()
    {
        ScaryMusicAudioSource.Play();
    }
    public void ScaryAmbientOff() 
    { 
        ScaryMusicAudioSource.Stop();
    }
    public void AlarmOn()
    {
        Alarm.Play();
    }
    public void AlarmOff() 
    { 
        Alarm.Stop();
    }
    public void BackOff(){
        MusicBack.Stop();
    }

}
