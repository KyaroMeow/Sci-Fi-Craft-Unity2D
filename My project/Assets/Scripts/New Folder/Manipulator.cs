using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
   public Transform firstElementPlace;
   public Transform secondElementPlace;
   public Transform resultElementPlace;
   public Animator animator;
   public ElementHolders firstElement;
   public ElementHolders secondElement;
   private Element resultElement;

    
    public void Cook()
    {
        if (firstElement.element != null && secondElement.element != null)
        {
            animator.SetTrigger("Button");
            Debug.Log("√Û‰");
        }
    }
}
