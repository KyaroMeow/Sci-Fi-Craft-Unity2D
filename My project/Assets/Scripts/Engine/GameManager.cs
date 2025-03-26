using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
  
    public Dictionary<int, bool> elementState = new Dictionary<int, bool>()
{
    {1, true},
    {2, true},
    {3, true},
    {4, true},
    {5, true},
    {6, true}, 
    {7, true},
    {8, true},
    {9, true}, 
    {10, true},
    {11, true},
    {12, true}, 
    {13, true},
    {14, true},
    {15, true}
};
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
    }
    

    public void LoadElementState()
    {
        for (int i = 1; i <= 15; i++)
        {
            if (i > 6)
            {
                string key = $"Element_{i}_is_open";
                if (PlayerPrefs.HasKey(key))
                {
                    elementState[i] = PlayerPrefs.GetFloat(key) == 1f;
                }
                else
                {
                    elementState[i] = false;
                }
            }
        }
    }
}
