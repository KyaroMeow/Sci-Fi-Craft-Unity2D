using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public RectTransform elementsPanel;
    public Vector2 targetPositionOpen;
    public Vector2 targetPositionClosed;
    public RectTransform ButtonImage;
    public float animationDuration = 1f;
    public GameObject[] elButtons;
    public int reactionCount;
    private bool IsElementsPanelOpen = true;
    public TextMeshProUGUI reactionCountText;
    public GameObject ElementDescriptionPanel;
    public TextMeshProUGUI DescriptionHeader;
    public TextMeshProUGUI DescriptionText;
    void Start()
    {
        CheckButtonState();
        reactionCount = PlayerPrefs.GetInt("ReactCount");
    }
    private void Update()
    {
        reactionCountText.text = $"{reactionCount}/10";
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
        if (IsElementsPanelOpen)
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
    private void CheckButtonState()
    {
      foreach(var element in GameManager.Instance.elementState)
      {
            SetInteractElButton(element.Key, element.Value);
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
    public void SetInteractElButton(int elementID, bool setState)
    {
        GameObject button = elButtons[elementID-1];
        button.GetComponent<Button>().interactable = setState;
        button.transform.Find("Image").gameObject.SetActive(setState);
        button.transform.Find("Question").gameObject.SetActive(!setState);
    }
}
