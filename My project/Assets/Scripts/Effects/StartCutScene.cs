using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCutScene : MonoBehaviour
{
    public string text;
    public float typingSpeed = 0.05f;
    public TextMeshProUGUI textBox;
    Animator animator;

    private void StartTyping()
    {
            textBox.text = "";
            StartCoroutine(TypeText(text));
    }
    public void StartFade()
    {
        animator.SetTrigger("StartFade");
    }
    private IEnumerator TypeText(string message)
    {
        textBox.text = "";
        foreach (char letter in message.ToCharArray())
        {
            if(letter == '/'){
            textBox.text += "\n";
            yield return new WaitForSeconds(typingSpeed);
            }
            else{
                textBox.text += letter;
            yield return new WaitForSeconds(typingSpeed);

            }
        }
    }
    public void StartText()
    {
        StartTyping();
    }
    public void EndCutScene(){
        gameObject.SetActive(false);
    }
}
