
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public float SFXVolume;
    public float MusicVolume;
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
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void SetVolume(string type,float volume)
    {
        switch(type){
            case "SFX":
            SFXVolume = volume;
            PlayerPrefs.SetFloat("SFXVolume",volume);
            break;
            case "Music":
            MusicVolume = volume;
            PlayerPrefs.SetFloat("MusicVolume",volume);
            break;
        }
    }
}
