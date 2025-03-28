using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEnd : MonoBehaviour
{
   public void ExitToMenu()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
