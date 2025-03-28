using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEnd : MonoBehaviour
{
    public Animator animator;
    void OnEnable()
    {
        SFXSource.Instance.PlayBoom();
    }
    public void StartTitr(){
    animator.SetTrigger("Fade");
    }
   public void ExitToMenu()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
