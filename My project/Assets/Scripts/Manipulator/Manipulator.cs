using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
   public Animator animator;
   public ElementHolders firstElement;
   public ElementHolders secondElement;
   public ElementHolders resultElement;
    private Dictionary<string, GameObject> reactionResults;
    
    
    public void Cook()
    {
        if (firstElement.element != null && secondElement.element != null)
        {
            animator.SetTrigger("Button");
            Debug.Log("���");
        }else{
            Debug.Log("null");
        }
    }
    public void Start()
    {
        int reactCount = 0;
        reactionResults = new Dictionary<string, GameObject>();

        // Заполнение реакций из элементов
        foreach (Element element in Resources.LoadAll<Element>("Elements"))
        {
            foreach (ElementReaction reaction in element.reactions)
            {
                string key = $"{element.elementName}+{reaction.elementName}";
                if (!reactionResults.ContainsKey(key))
                {
                    reactionResults.Add(key, reaction.resultPrefab);
                    reactCount++;
                }
            }
        }
        Debug.Log("react add:"+ reactCount);
    }
    public void HideElements()
    {
        firstElement.ElementImage.sprite = null;
        secondElement.ElementImage.sprite = null;
        //resultElement.element = GetResult(firstElement.element,secondElement.element);
        string key = $"{firstElement.element.elementName}+{secondElement.element.elementName}";
        if (reactionResults.ContainsKey(key))
        {
            GameObject resultPrefab = reactionResults[key];
            Instantiate(resultPrefab, resultElement.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Реакция не определена.");
        }
        firstElement.element = null;
        secondElement.element = null;
    }
    
    
    public void ShowResult()
    {

    }
}
