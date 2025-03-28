using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public GameObject panel;
    public List<string> messages;
    [Range(0.01f, 1f)]
    public float typingSpeed = 0.05f;
    public TextMeshProUGUI uiText;
    public Animator RedLightBack;
    public Animator RedLightManipulator;
    public Animator CrystalAnimator;
    public GameObject Crystal;
    public Image image;
    public Sprite Scary;
    public Sprite Fear;
    public Sprite Wow;
    public Sprite Cry;
    public Sprite Good;
    public GameObject FinalBoomPanel;
    private Coroutine typingCoroutine;
    private int currentMessageIndex = 0;
    private bool isTyping = false;

    void OnEnable()
    {
        if (messages != null && messages.Count > 0)
        {
            StartTyping();
        }
        Crystal.SetActive(true);


    }
    private void StartTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        if (currentMessageIndex < messages.Count)
        {
            uiText.text = "";
            typingCoroutine = StartCoroutine(TypeText(messages[currentMessageIndex]));
            isTyping = true;
        }
    }
    private void StopTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            uiText.text = messages[currentMessageIndex];
            isTyping = false;
        }
    }
    private IEnumerator TypeText(string message)
    {
        uiText.text = "";
        foreach (char letter in message.ToCharArray())
        {
            uiText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
    private void FinalBoom()
    {
        FinalBoomPanel.SetActive(true);
    }
    public void NextMessage()
    {
        if (!isTyping)
        {
            if (currentMessageIndex < messages.Count - 1)
            {
                currentMessageIndex++;
                StartTyping();
                switch (currentMessageIndex)
                {
                    case 5:
                        image.sprite = Good;
                        break;
                    case 7:
                        SFXSource.Instance.ScaryAmbientOn();
                        CrystalAnimator.SetTrigger("Pulse");
                        image.sprite = Scary;
                        break;
                    case 8:
                        SFXSource.Instance.AlarmOn();
                        RedLightBack.SetTrigger("Alarm");
                        RedLightManipulator.SetTrigger("Alarm");
                        break;
                    case 9:
                        image.sprite = Fear;
                        break;
                    case 10:
                        image.sprite = Cry;
                        break;
                }
            }
            else
            {
                panel.SetActive(false);
                FinalBoom();
                
            }
        }
        else
        {
            StopTyping();
        }
    }
}