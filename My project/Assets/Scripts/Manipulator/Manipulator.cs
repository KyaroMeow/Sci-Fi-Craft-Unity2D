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
        
    }
    public void NewElements()
    {
        string key = $"{firstElement.element.elementName}+{secondElement.element.elementName}";
        if (reactionResults.ContainsKey(key))
        {
            GameObject resultPrefab = reactionResults[key];
            Instantiate(resultPrefab, resultElement.transform.position, Quaternion.identity);
            CheckNewElement(resultPrefab);
        }
        else
        {
            Debug.Log("Реакция не определена.");
        }
        firstElement.element = null;
        secondElement.element = null;
    }
    
    
    public void CheckNewElement(GameObject element)
    {

        ElementBehaviour elementBehaviour = element.GetComponent<ElementBehaviour>();
        if (elementBehaviour != null)
        {
            if (GameManager.Instance.elementState[elementBehaviour.Id] == false)//if new
            {
            GameManager.Instance.elementState[elementBehaviour.Id] = true;
            string key = $"Element_{elementBehaviour.Id}_is_open";
            PlayerPrefs.SetFloat(key,1f);
            UIManager.Instance.SetInteractElButton(elementBehaviour.Id,true);
            UIManager.Instance.reactionCount++;
            PlayerPrefs.SetInt("ReactCount",UIManager.Instance.reactionCount);
            }
        }
    }
}
