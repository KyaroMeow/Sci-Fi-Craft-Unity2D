using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    public void NextMessage()
    {
        if (!isTyping)
        {
            if (currentMessageIndex < messages.Count - 1)
            {
                currentMessageIndex++;
                StartTyping();
                if (currentMessageIndex == 8)
                {
                    CrystalAnimator.SetTrigger("Pulse");
                }
            }
            else
            {
                panel.SetActive(false);
            }
        }
    }
}