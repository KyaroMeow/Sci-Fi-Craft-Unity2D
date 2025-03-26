using UnityEngine;

public class SFXSource : MonoBehaviour
{
    public static SFXSource Instance;

    public AudioSource audioSource;
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
        audioSource.PlayOneShot(hower);
    }
    public void PlayClick(){
        audioSource.PlayOneShot(click);
    }
    public void PlayCoock(){
        audioSource.PlayOneShot(coock);
    }
    public void PlayError(){
        audioSource.PlayOneShot(error);
    }
}
