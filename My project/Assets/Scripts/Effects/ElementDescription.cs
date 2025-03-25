using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElementDescription : MonoBehaviour
{
    public string Name;
    public string Description;
    public void ShowDescription()
    {
        UIManager.Instance.DescriptionHeader.text = Name;
        UIManager.Instance.DescriptionText.text = Description;
        UIManager.Instance.ElementDescriptionPanel.SetActive(true);
    }
    public void HideDescription()
    {
        UIManager.Instance.ElementDescriptionPanel.SetActive(false);
    }
    
}
