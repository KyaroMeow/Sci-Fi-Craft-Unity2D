
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManagerMenu : MonoBehaviour
{
    public Slider SFXVolumeSlider;
    public Slider MusicVolumeSlider;
    public void SetVolumeSettings()
    {
        AudioManager.Instance.SetVolume("SFX",SFXVolumeSlider.value);
        AudioManager.Instance.SetVolume("Music",MusicVolumeSlider.value);
    }
    void OnEnable()
    {
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("SFXVolume",1f);
        PlayerPrefs.SetFloat("MusicVolume",1f);
    }
    public void StartGame()
    {
        GameManager.Instance.LoadElementState();
        SceneManager.LoadScene(1);
    }

}
