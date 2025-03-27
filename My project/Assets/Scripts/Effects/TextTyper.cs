using UnityEngine;
using System.Collections;
using System;
using TMPro;
using System.Collections.Generic;

public class TextTyper : MonoBehaviour
{
    public GameObject panel;
    public List<string> messages;
    [Range(0.01f, 1f)]
    public float typingSpeed = 0.05f;
    public bool autoAdvance = true;
    public TextMeshProUGUI uiText;
    public Animator animator;
    private Coroutine typingCoroutine;
    private int currentMessageIndex = 0;
    private bool isTyping = false;

    void OnEnable()
    {
        if (messages != null && messages.Count > 0)
        {
            StartTyping();
        }
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

        if (autoAdvance && currentMessageIndex < messages.Count - 1)
        {
            currentMessageIndex++;
            yield return new WaitForSeconds(1f);
            StartTyping();
        }
    }
    public void NextMessage()
    {
        if (isTyping)
        {
            StopTyping();
        }
        else
        {
            if (currentMessageIndex < messages.Count - 1)
            {
            currentMessageIndex++;
            StartTyping();
                if (currentMessageIndex == 7)
                {
                    animator.SetTrigger("MoveLeft");
                }
            }
            else
            {
                panel.SetActive(false);
            }
        }
    }
}

