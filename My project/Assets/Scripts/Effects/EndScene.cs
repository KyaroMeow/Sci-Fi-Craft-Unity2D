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
    }
    public void NextMessage()
    {
        if (!isTyping)
        {
            if (currentMessageIndex < messages.Count - 1)
            {
                currentMessageIndex++;
                StartTyping();
                if (currentMessageIndex == 1)
                {
                    //animator.SetTrigger("MoveRight");
                }
            }
            else
            {
                panel.SetActive(false);
            }
        }
    }
}