using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public RectTransform elementsPanel;
    public Vector2 targetPositionOpen; 
    public Vector2 targetPositionClosed; 
    public RectTransform ButtonImage;
    public float animationDuration = 1f;
    private bool IsElementsPanelOpen = true;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
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
    public void ClickElementsPanel()
    {
     if(IsElementsPanelOpen)
     {
        IsElementsPanelOpen = !IsElementsPanelOpen;
        Vector2 currentScale = ButtonImage.localScale;
        currentScale.x *= -1;
        ButtonImage.localScale = currentScale;
        ClosePanel();
     }
     else
     {
        IsElementsPanelOpen = !IsElementsPanelOpen;
        Vector2 currentScale = ButtonImage.localScale;
        currentScale.x *= -1;
        ButtonImage.localScale = currentScale;
        OpenPanel();
     }

    }
    private void OpenPanel()
    {
        elementsPanel.DOAnchorPos(targetPositionOpen, animationDuration).SetEase(Ease.OutQuad);
    }
    private void ClosePanel()
    {
        elementsPanel.DOAnchorPos(targetPositionClosed, animationDuration).SetEase(Ease.OutQuad);
    }
}
