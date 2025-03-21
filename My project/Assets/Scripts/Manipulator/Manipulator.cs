using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
   public Animator animator;
   public ElementHolders firstElement;
   public ElementHolders secondElement;
   public ElementHolders resultElement;
   

    
    public void Cook()
    {
        if (firstElement.element != null && secondElement.element != null)
        {
            animator.SetTrigger("Button");
            Debug.Log("���");
        }
    }
    public void HideElements()
    {
        firstElement.ElementImage.sprite = null;
        secondElement.ElementImage.sprite = null;
        resultElement.element = CheckResult(firstElement.element,secondElement.element);
        firstElement.element = null;
        secondElement.element = null;
    }
    private Element CheckResult(Element firstEl,Element secondEl)
    {
        return new Element();
    }
    public void ShowResult()
    {

    }
}
